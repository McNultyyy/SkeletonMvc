using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Core.Entities;

using DAL.Repository;
using DAL.Repository.Conventions;

namespace DAL
{
    public class SkeletonMvcContext : DbContext, IContext
    {
        public SkeletonMvcContext()
        {
            Database.SetInitializer<SkeletonMvcContext>(null);
        }

        public IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity, IEntity
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.AddBefore<ForeignKeyIndexConvention>(new ForeignKeyNamingConvention());

            // DYNAMIC WAY OF MAPPING OUR ENTITIES
            var allTypes = AppDomain.CurrentDomain
                .GetAssemblies().SelectMany(x => x.GetTypes());

            var typesToRegister = allTypes
                .Where(type => !string.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null
                               && type.BaseType.IsGenericType
                               && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var addedEntities = ChangeTracker.Entries<Entity>()
                .Where(x => x.State == EntityState.Added)
                .Select(x => x.Entity);

            var updatedEntities = ChangeTracker.Entries<Entity>()
                .Where(x => x.State == EntityState.Modified)
                .Select(x => x.Entity);

            return base.SaveChanges();
        }

        public void RollBack()
        {
            base.Dispose();
        }

    }
}
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading;
using DAL.Models.Entities;
using DAL.Models.Interfaces;
using DAL.Repository;
using DAL.Repository.Conventions;

namespace DAL
{
    public class SkeletonMvcContext : DbContext, IContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogAudit> BlogAudits { get; set; }

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
            var modifiedEntries = ChangeTracker.Entries().Where(x =>
                x.GetType().GetInterfaces().Contains(typeof(IAudits<>)) &&
                (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var modifiedEntry in modifiedEntries)
            {
                var entity = modifiedEntry.Entity as IAudits<Entity>;

                if (entity != null)
                {
                    var action = modifiedEntry.State.ToString();
                    var username = Thread.CurrentPrincipal.Identity.Name ?? "Unknown";
                    var date = DateTime.Now;

                    entity.Action = action;
                    entity.ChangedBy = username;
                    entity.ChangeDate = date;
                }

            }
            return base.SaveChanges();
        }
    }
}
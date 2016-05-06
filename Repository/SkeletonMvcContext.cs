using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using Model;

namespace Repository
{
    public class SkeletonMvcContext : DbContext, IContext
    {

        public SkeletonMvcContext()
        {
            //Database.SetInitializer<SkeletonMvcContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //DYNAMIC WAY OF MAPPING OUR ENTITIES
            var typesToRegister = Assembly.GetAssembly(typeof(BaseEntity)).GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null &&
                               type.BaseType.IsGenericType &&
                               type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>)
                );

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            //MANUAL WAY OF MAPPING OUR ENTITIES
            //modelBuilder.Configurations.Create(new AuthorMap());
            //modelBuilder.Configurations.Create(new BlogPostMap());

            base.OnModelCreating(modelBuilder);
        }


        public IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity, IEntity
        {
            return base.Set<TEntity>();
        }
    }


    public interface IContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity, IEntity;

        int SaveChanges();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

    }
}
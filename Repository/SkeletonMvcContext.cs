namespace Repository
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using System.Reflection;

    using Model;

    public class SkeletonMvcContext : DbContext, IContext
    {

        public SkeletonMvcContext()
        {
            // Database.SetInitializer<SkeletonMvcContext>(null);
        }

        public IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity, IEntity
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // DYNAMIC WAY OF MAPPING OUR ENTITIES
            var typesToRegister = Assembly.GetAssembly(typeof(BaseEntity)).GetTypes()
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
    }
}
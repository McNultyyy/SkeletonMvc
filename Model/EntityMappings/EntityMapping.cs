using System.Data.Entity.ModelConfiguration;

namespace Model.EntityMappings
{
    public class EntityMapping : EntityTypeConfiguration<Entity>
    {
        public EntityMapping()
        {
            Property(x => x.RowVersion).IsRowVersion();
        }
    }
}
using System.Data.Entity.ModelConfiguration;
using Repository.Model.Entities;

namespace Mapper.EntityMappings
{
    public class PersonMapping : EntityTypeConfiguration<Person>
    {
        public PersonMapping()
        {
            ToTable("Person");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Id");

            Property(x => x.RowVersion).IsRowVersion();

            Property(x => x.Name);
            HasMany(x => x.AuditEntities)
                .WithRequired(x => x.Entity)
                .HasForeignKey(x => x.EntityId);

        }
    }
}
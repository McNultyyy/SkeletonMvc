using System.Data.Entity.ModelConfiguration;
using Model.Entities;

namespace Mapper.EntityMappings
{
    public class BlogMapping : EntityTypeConfiguration<Blog>
    {
        public BlogMapping()
        {
            ToTable("Blog");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Id");

            Property(x => x.RowVersion).IsRowVersion();

            Property(x => x.Name);
            Property(x => x.Description);
           
        }
    }
}
using System.Data.Entity.ModelConfiguration;
using Repository.Models.Entities;

namespace Repository.EntityMappings
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
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Model.Entities;

namespace Model.EntityMappings
{
    public class EmployeeMapping : EntityTypeConfiguration<Employee>
    {
        public EmployeeMapping()
        {
            ToTable("Employee");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Id");

            Property(x => x.FirstName).HasColumnName("FirstName");
            Property(x => x.LastName).HasColumnName("LastName");
            Property(x => x.KnownAs).HasColumnName("KnownAs");
        }
    }
}
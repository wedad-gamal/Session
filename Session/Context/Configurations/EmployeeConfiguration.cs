using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Session.Entities;

namespace Session.Context.Configurations
{
    class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {

            builder.HasKey(e => e.Id);


            builder.Property(e => e.Name)
                .IsRequired(false)
                .HasMaxLength(50);

            builder.Property(e => e.Salary)
                .HasColumnType("decimal(18,5)");

            builder.Property(e => e.Description)
                .IsRequired(false);


        }
    }
}

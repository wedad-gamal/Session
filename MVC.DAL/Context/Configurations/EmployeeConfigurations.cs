using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MVC.DAL.Context.Configurations
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Salary).HasColumnType("decimal(18,3)");
            builder.HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.City)
                .WithMany(City => City.Employees)
                .HasForeignKey(e => e.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Country)
                .WithMany(c => c.Employees)
                .HasForeignKey(e => e.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

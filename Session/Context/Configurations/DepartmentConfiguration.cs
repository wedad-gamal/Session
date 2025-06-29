using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Session.Entities;

namespace Session.Context.Configurations
{
    class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            //builder.HasOne(d => d.Manager)
            //       .WithOne(e => e.Department)
            //       //HasForeignKey => takes the entity that has the foreign key
            //-1- by convention
            //.HasForeignKey<Department>();
            //-2- by specify with func
            //.HasForeignKey<Department>(d => d.ManagerId);
            //-3- by specify with string
            //.HasForeignKey<Department>("ManagerId");

            //builder.HasMany<Employee>(d => d.Employees)
            //        .WithOne(e => e.EmployeeDepartment)
            //        .HasForeignKey(e => e.DeptId);

            //builder.HasOne<Employee>(e => e.Manager)
            //       .WithOne()
            //       .HasForeignKey<Department>(d => d.ManagerId)
            //       .OnDelete(DeleteBehavior.Restrict);

            //builder.HasMany<Employee>(e => e.Employees)
            //       .WithOne(d => d.Department)
            //       .HasForeignKey(e => e.DepartmentId)
            //       .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Session.DTOs;
using Session.Entities;

namespace Session.Context
{
    public class DataContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //    modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            //    modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            #region Many to Many

            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //modelBuilder.Entity<Student>()
            //            .HasMany<Course>()
            //            .WithMany()
            //            .UsingEntity<CourseStudent>()
            //            .HasKey(cs => new { cs.StudentId, cs.CourseId });

            //modelBuilder.Entity<Student>()
            //             .HasMany(s => s.CourseStudent)
            //             .WithOne()
            //             .HasForeignKey(cs => cs.StudentId)
            //             .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Course>()
            //            .HasMany(c => c.CourseStudent)
            //            .WithOne()
            //            .HasForeignKey(cs => cs.CourseId)
            //            .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<CourseStudent>()
            //            .HasKey(cs => new { cs.StudentId, cs.CourseId });

            #endregion
            #region TPH
            //modelBuilder.Entity<FullTimeEmployee>()
            //                .HasBaseType<CompanyEmployee>();

            //modelBuilder.Entity<PartTimeEmployee>()
            //            .HasBaseType<CompanyEmployee>()
            //            .HasDiscriminator<string>("EmployeeType"); 
            #endregion

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Employees)
                .WithOne(e => e.Manager)
                .HasForeignKey(e => e.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne<Department>()
                .WithOne(d => d.Manager)
                .HasForeignKey<Department>(d => d.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DepartmentEmployees>()
                .HasNoKey()
                .ToView("DepartmentEmployeesView");




        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("data source= . ; initial catalog = Session ; user id = sa; password = P@ssw0rd; TrustServerCertificate=True");
            optionsBuilder
                .UseLazyLoadingProxies() // Enable lazy loading
                .UseSqlServer("server = . ; database = Session ; user id = sa; password = P@ssw0rd; TrustServerCertificate=True");
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentEmployees> DepartmentEmployees { get; set; }
        //public DbSet<Course> Courses { get; set; }
        //public DbSet<Student> Students { get; set; }
        //public DbSet<CourseStudent> CourseStudent { get; set; }
        //public DbSet<CompanyEmployee> Employees { get; set; }

        //public DbSet<CompanyEmployee> Employees { get; set; }
        //public DbSet<FullTimeEmployee> FullTimeEmployee { get; set; }
        //public DbSet<PartTimeEmployee> PartTimeEmployee { get; set; }

        public List<Employee> GetEmployeesByDepartment(int departmentId)
        {
            var departmentIdParameter = new SqlParameter()
            {
                ParameterName = "@DepartmentId",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = departmentId,
                Direction = System.Data.ParameterDirection.Input
            };
            return Employees.FromSqlRaw("EXEC GetEmployeesByDepartment @DepartmentId",
                  departmentIdParameter).ToList();
        }

        public List<EmployeeWithDepartmentDetailsDto> GetEmployeeWithDepartmentDetails(int departmentId)
        {

            return this.Database
                .SqlQueryRaw<EmployeeWithDepartmentDetailsDto>($"exec GetAllEmployeeNamesbyDepartmentId {departmentId}")
                .ToList();
        }

        public string GetDepartmentName(int departmentId)
        {
            var departmentIdParameter = new SqlParameter()
            {
                ParameterName = "@departmentId",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = departmentId,
                Direction = System.Data.ParameterDirection.Input
            };
            var departmentNameParameter = new SqlParameter()
            {
                ParameterName = "@departmentName",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 20,
                Direction = System.Data.ParameterDirection.Output
            };
            this.Database.ExecuteSqlRaw("EXEC GetDepartmentName @departmentId, @departmentName OUTPUT",
                departmentIdParameter, departmentNameParameter);
            return departmentNameParameter.Value?.ToString() ?? string.Empty;
        }
    }
}

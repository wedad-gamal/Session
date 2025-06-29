using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Session.Migrations
{
    /// <inheritdoc />
    public partial class addView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create view DepartmentEmployeesView
as 
select e.Id EmployeeId ,e.Name EmployeeName, d.Id DepartmentId , d.Name DepartmentName
from Employees e, Departments d
where e.DepartmentId = d.Id");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop view DepartmentEmployeesView");
        }
    }
}

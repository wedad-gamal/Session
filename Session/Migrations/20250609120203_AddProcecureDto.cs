using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Session.Migrations
{
    /// <inheritdoc />
    public partial class AddProcecureDto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create or alter procedure GetAllEmployeeNamesbyDepartmentId
@DepartmentId int
as 
begin
select e.Id EmployeeId ,e.Name EmployeeName, d.Id DepartmentId , d.Name DepartmentName
from Employees e, Departments d
where e.DepartmentId = d.Id and d.Id = @DepartmentId
end");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE IF EXISTS GetAllEmployeeNamesbyDepartmentId");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Session.Migrations
{
    /// <inheritdoc />
    public partial class addPrecdureWithOut : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create procedure GetDepartmentName
@departmentId int,
@departmentName varchar(20) output
as
begin
select @departmentName = d.Name
from Departments d
where d.Id = @departmentId
end");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE IF EXISTS GetDepartmentName");
        }
    }
}

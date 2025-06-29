using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Session.Migrations
{
    /// <inheritdoc />
    public partial class AddStoreProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE GetEmployeesByDepartment
                @DepartmentId INT
                AS
                BEGIN
                    SELECT * FROM Employees WHERE DepartmentId = @DepartmentId
                END");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP PROCEDURE IF EXISTS GetEmployeesByDepartment");
        }
    }
}

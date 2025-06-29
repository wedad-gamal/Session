using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Session.Context;
using Session.Entities;

namespace Session.Dapper
{
    public static class Queries
    {
        public static void QueryMethod()
        {
            //using SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=Session;Integrated Security=True;Trust Server Certificate=True");


            //using SqlConnection connection = new DataContext().Database.GetDbConnection() as SqlConnection;

            DataContext context = new DataContext();
            using SqlConnection connection = context.Database.GetDbConnection() as SqlConnection;

            #region Query- retrieve data
            var employees = connection.Query<Employee>("select * from employees").ToList();
            employees.ForEach(e => Console.WriteLine($"{e.Id} {e.Name} {e.DepartmentId}"));
            #endregion

            #region Stored procedure

            //var parameter = new DynamicParameters();
            //parameter.Add("@DepartmentId", 1, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            //var employees = connection.Query<EmployeeWithDepartmentDetailsDto>(
            //    "GetAllEmployeeNamesbyDepartmentId",
            //    parameter,
            //    commandType: System.Data.CommandType.StoredProcedure);

            //var employees = connection.Query<EmployeeWithDepartmentDetailsDto>(
            //    "GetAllEmployeeNamesbyDepartmentId",
            //    new
            //    {
            //        DepartmentId = 1
            //    },
            //    commandType: System.Data.CommandType.StoredProcedure);

            //foreach (var employee in employees)
            //{
            //    Console.WriteLine($"{employee.EmployeeName} :: {employee.DepartmentName}");
            //}


            #endregion

            #region Execute

            //var rowsAffected = connection.Execute("update Employees set Name = 'Updated Name' where Id = 3");
            //Console.WriteLine(rowsAffected);

            //connection.Query("update Employees set Name = 'Updated Name2' where Id = @Id", new { Id = 3 });

            //var rows = connection.Execute("delete from Employees where Id = @Id", new { Id = 3 });
            //Console.WriteLine(rows);

            //connection.Execute("GetAllEmployeeNamesbyDepartmentId", new
            //{
            //    DepartmentId = 1
            //},
            //    commandType: System.Data.CommandType.StoredProcedure);
            #endregion


        }

    }
}

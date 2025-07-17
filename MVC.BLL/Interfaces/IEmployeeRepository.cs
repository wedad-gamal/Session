namespace MVC.BLL.Interfaces
{
    public interface IEmployeeRepository : IGenereicRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetALlIncludeNameAsync(string name);
    }
}

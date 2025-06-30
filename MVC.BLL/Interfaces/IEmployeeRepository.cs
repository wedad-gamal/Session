namespace MVC.BLL.Interfaces
{
    public interface IEmployeeRepository : IGenereicRepository<Employee>
    {
        IEnumerable<Employee> GetALlIncludeName(string name);
    }
}

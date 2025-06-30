

namespace MVC.BLL.Repositories
{
    public class EmployeeRepository : GenereicRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public IEnumerable<Employee> GetALlIncludeName(string name)
        {
            var data = _dbSet.Where(e => string.IsNullOrEmpty(name) || e.Name.ToLower().Contains(name.ToLower())).ToList();
            return data;
        }
    }
}

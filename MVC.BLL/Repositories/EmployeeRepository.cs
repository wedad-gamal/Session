

using Microsoft.EntityFrameworkCore;

namespace MVC.BLL.Repositories
{
    public class EmployeeRepository : GenereicRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<IEnumerable<Employee>> GetALlIncludeNameAsync(string name)
        {
            var data = await _dbSet.Where(e => string.IsNullOrEmpty(name) || e.Name.ToLower().Contains(name.ToLower())).ToListAsync();
            return data;
        }
    }
}

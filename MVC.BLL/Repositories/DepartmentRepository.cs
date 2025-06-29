using MVC.BLL.Interfaces;
using MVC.DAL.Context;
using MVC.DAL.Entities;

namespace MVC.BLL.Repositories
{
    public class DepartmentRepository : GenereicRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public Department? GetByName(string name)
            => _dbSet.Where(d => d.Name == name).FirstOrDefault();

    }
}

using MVC.DAL.Entities;

namespace MVC.BLL.Interfaces;
public interface IDepartmentRepository : IGenereicRepository<Department>
{
    Department? GetByName(string name);
}
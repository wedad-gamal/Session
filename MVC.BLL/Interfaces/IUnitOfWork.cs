namespace MVC.BLL.Interfaces
{
    public interface IUnitOfWork
    {
        public IEmployeeRepository Employees { get; }
        public IDepartmentRepository Departments { get; }
        public IGenereicRepository<Country> Countries { get; }
        public IGenereicRepository<City> Cities { get; }
        public int SaveChanges();
    }
}

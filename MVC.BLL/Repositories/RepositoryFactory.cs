namespace MVC.BLL.Repositories
{

    public class RepositoryFactory : IRepositoryFactory
    {
        public IGenereicRepository<City> CreateCityRepository(DataContext context)
             => new GenereicRepository<City>(context);

        public IGenereicRepository<Country> CreateCountryRepository(DataContext context)
            => new GenereicRepository<Country>(context);

        public IDepartmentRepository CreateDepartmentRepository(DataContext context)
             => new DepartmentRepository(context);

        public IEmployeeRepository CreateEmployeeRepository(DataContext context)
            => new EmployeeRepository(context);
    }
}

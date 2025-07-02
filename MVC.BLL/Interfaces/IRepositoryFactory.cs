namespace MVC.BLL.Interfaces
{
    public interface IRepositoryFactory
    {
        IGenereicRepository<City> CreateCityRepository(DataContext context);
        IGenereicRepository<Country> CreateCountryRepository(DataContext context);
        IDepartmentRepository CreateDepartmentRepository(DataContext context);
        IEmployeeRepository CreateEmployeeRepository(DataContext context);

    }
}

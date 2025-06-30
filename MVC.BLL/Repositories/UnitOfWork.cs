namespace MVC.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IGenereicRepository<Country> _countryRepository;
        private readonly IGenereicRepository<City> _cityRepoitory;
        private readonly DataContext _dataContext;

        public UnitOfWork(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository,
            IGenereicRepository<Country> countryRepository, IGenereicRepository<City> cityRepoitory,
            DataContext dataContext)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            _countryRepository = countryRepository;
            _cityRepoitory = cityRepoitory;
            _dataContext = dataContext;
        }
        public IEmployeeRepository Employees => _employeeRepository;

        public IDepartmentRepository Departments => _departmentRepository;

        public IGenereicRepository<Country> Countries => _countryRepository;

        public IGenereicRepository<City> Cities => _cityRepoitory;

        public int SaveChanges() => _dataContext.SaveChanges();
    }
}





namespace MVC.Presentation.MappingProfile.Resolvers;

public class CountryListResolver : IValueResolver<Employee, EmployeeViewModel, IEnumerable<SelectListItem>>
{
    private readonly IGenereicRepository<Country> _genereicRepository;

    public CountryListResolver(IGenereicRepository<Country> genereicRepository)
    {
        _genereicRepository = genereicRepository;
    }
    public IEnumerable<SelectListItem> Resolve(Employee source, EmployeeViewModel destination, IEnumerable<SelectListItem> destMember, ResolutionContext context)
    {
        return _genereicRepository.GetAll().Select(c => new SelectListItem()
        {
            Value = c.Id.ToString(),
            Text = c.Name
        });
    }
}

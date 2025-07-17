namespace MVC.Presentation.MappingProfile.Resolvers;

public class DepartmentListResolver : IValueResolver<Employee, EmployeeViewModel, IEnumerable<SelectListItem>>
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentListResolver(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }


    public IEnumerable<SelectListItem> Resolve(Employee source, EmployeeViewModel destination, IEnumerable<SelectListItem> destMember, ResolutionContext context)
    {
        return _departmentRepository.GetAllAsync().Result.Select(d => new SelectListItem
        {
            Value = d.Id.ToString(),
            Text = d.Name
        });
    }
}


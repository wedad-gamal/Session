

using MVC.DAL.Entities;
using MVC.Presentation.ViewModels;

namespace MVC.Presentation.MappingProfile;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeViewModel>()
            .ReverseMap();
    }
}

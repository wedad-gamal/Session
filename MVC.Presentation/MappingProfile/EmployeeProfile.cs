using MVC.Presentation.MappingProfile.Resolvers;

namespace MVC.Presentation.MappingProfile;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeViewModel>()
    .ForMember(dest => dest.GenderList,
               opt => opt.MapFrom(src =>
                   new SelectList(Enum.GetValues(typeof(Gender)))))
    .ForMember(dest => dest.IsEditMode, opt => opt.Ignore()) // You still set this in controller
    .ForMember(dest => dest.Departments,
             opt => opt.MapFrom<DepartmentListResolver>())
    .ForMember(dest => dest.Countries,
             opt => opt.MapFrom<CountryListResolver>())
    .ForMember(dest => dest.DepartmentName,
            opt => opt.MapFrom(src => src.Department != null ? src.Department.Name : ""))
    .ForMember(dest => dest.CountryName,
            opt => opt.MapFrom(src => src.Country != null ? src.Country.Name : ""))
    .ForMember(dest => dest.CityName,
            opt => opt.MapFrom(src => src.City != null ? src.City.Name : ""))

    .ReverseMap();
    }
}

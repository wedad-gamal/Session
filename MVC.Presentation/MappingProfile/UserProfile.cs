using MVC.BLL.DTOs;

namespace MVC.Presentation.MappingProfile;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<ApplicationUser, UserViewModel>()
            .ForMember(u => u.Roles,
            u => u.MapFrom<ApplicationUserRolesResolver>());

        CreateMap<RoleDto, RoleViewModel>().ReverseMap();
        CreateMap<RoleDto, UserRoleViewModel>().ReverseMap();

    }
}

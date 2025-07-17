using Microsoft.AspNetCore.Identity;

namespace MVC.Presentation.MappingProfile;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<IdentityRole, RoleViewModel>().ReverseMap();
    }
}

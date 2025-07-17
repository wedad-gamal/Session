using Microsoft.AspNetCore.Identity;

namespace MVC.Presentation.MappingProfile.Resolvers;

public class ApplicationUserRolesResolver : IValueResolver<ApplicationUser, UserViewModel, string>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public ApplicationUserRolesResolver(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    public string Resolve(ApplicationUser source, UserViewModel destination, string destMember, ResolutionContext context)
    {
        return string.Join(",", _userManager.GetRolesAsync(source).Result.ToList());
    }
}

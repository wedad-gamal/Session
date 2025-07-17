using Microsoft.AspNetCore.Identity;
using MVC.BLL.DTOs;

namespace MVC.BLL.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> AssignRoleToUserAsync(string userId, string roleName);
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
        Task<ApplicationUser> GetUserByIdAsync(string userId);
        Task<ApplicationUser> GetUserByUserNameAsync(string userName);
        Task<IdentityResult> UpdateUserAsync(ApplicationUser user);
        Task DeleteUserAsync(ApplicationUser user);
        Task<IdentityResult> RemoveRoleFromUserAsync(string userId, string roleName);
        Task<List<RoleDto>> GetUserRolesDtoAsync(string userId);
        Task<IList<string>> GetUserRolesAsync(string userId);
    }
}

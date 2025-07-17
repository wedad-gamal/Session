using Microsoft.AspNetCore.Identity;

namespace MVC.BLL.Interfaces
{
    public interface IRoleService
    {
        Task<IdentityResult> CreateRoleAsync(string roleName);
        Task<IEnumerable<IdentityRole>> GetAsync();
        Task<IdentityRole> GetByIdAsync(string id);
        Task<IdentityResult> RemoveRoleAsync(string roleName);
        Task<IdentityResult> UpdateRoleAsync(IdentityRole role);
    }
}

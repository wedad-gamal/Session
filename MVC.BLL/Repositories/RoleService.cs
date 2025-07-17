using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MVC.BLL.Repositories
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RoleService> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleService(RoleManager<IdentityRole> roleManager, ILogger<RoleService> logger,
            UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateRoleAsync(string roleName)
        {
            _logger.LogInformation("Attempting to create role: {RoleName}", roleName);

            var result = await _roleManager.CreateAsync(new IdentityRole(roleName));

            if (!result.Succeeded)
                foreach (var error in result.Errors)
                    _logger.LogWarning("Failed to create role {RoleName}: {Error}", roleName, error.Description);
            return result;
        }

        public async Task<IEnumerable<IdentityRole>> GetAsync() => await _roleManager.Roles.ToListAsync();

        public async Task<IdentityRole> GetByIdAsync(string id) => await _roleManager.FindByIdAsync(id);
        public async Task<IdentityResult> RemoveRoleAsync(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded)
                foreach (var error in result.Errors)
                    _logger.LogWarning("Failed to delete role {RoleName}: {Error}", roleName, error.Description);
            return result;
        }

        public Task<IdentityResult> UpdateRoleAsync(IdentityRole role)
        {
            _logger.LogInformation("Updating role: {RoleName}", role.Name);
            var result = _roleManager.UpdateAsync(role);
            if (!result.Result.Succeeded)
            {
                foreach (var error in result.Result.Errors)
                {
                    _logger.LogWarning("Failed to update role {RoleName}: {Error}", role.Name, error.Description);
                }
            }
            return result;
        }
    }
}

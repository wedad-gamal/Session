using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVC.BLL.DTOs;

namespace MVC.BLL.Repositories
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(ILogger<UserService> logger, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IdentityResult> AssignRoleToUserAsync(string userId, string roleName)
        {
            _logger.LogInformation("Assigning role {RoleName} to user {UserId}", roleName, userId);

            var user = await _userManager.FindByIdAsync(userId);

            var result = await _userManager.AddToRoleAsync(user, roleName);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    _logger.LogWarning("Failed to assign role {RoleName} to user {UserId}: {Error}", roleName, userId, error.Description);
                }
                throw new InvalidOperationException($"Failed to assign role {roleName} to user {userId}");
            }
            return result;
        }

        public async Task DeleteUserAsync(ApplicationUser user) => await _userManager.DeleteAsync(user);

        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync() => await _userManager.Users.ToListAsync();

        public async Task<ApplicationUser> GetUserByIdAsync(string userId) => await _userManager.FindByIdAsync(userId);

        public async Task<ApplicationUser> GetUserByUserNameAsync(string userName) => await _userManager.FindByNameAsync(userName);

        public async Task<List<RoleDto>> GetUserRolesDtoAsync(string userId)
        {
            _logger.LogInformation(userId, "Getting roles for user {UserId}", userId);

            var user = await _userManager.FindByIdAsync(userId);

            var userRoles = await _userManager.GetRolesAsync(user);

            var allRoles = await _roleManager.Roles.ToListAsync();

            var roles = allRoles.Select(role => new RoleDto()
            {
                Id = role.Id,
                Name = role.Name,
                IsAssigned = userRoles.Contains(role.Name)
            }).ToList();

            return roles;

        }

        public async Task<IdentityResult> RemoveRoleFromUserAsync(string userId, string roleName)
        {
            _logger.LogInformation($"Remove Role from User {userId} - role {roleName}");

            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                var result = await _userManager.RemoveFromRoleAsync(user, roleName);

                if (result.Succeeded)
                    return result;

                foreach (var error in result.Errors)
                {
                    _logger.LogError($"Error to remove {roleName} from {user.Id} - {error.Description}");
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public async Task<IdentityResult> UpdateUserAsync(ApplicationUser user) => await _userManager.UpdateAsync(user);

        public async Task<IList<string>> GetUserRolesAsync(string userId)
        {
            _logger.LogInformation(userId, "Getting roles for user {UserId}", userId);

            var user = await _userManager.FindByIdAsync(userId);

            var userRoles = await _userManager.GetRolesAsync(user);
            return userRoles;


        }
    }
}

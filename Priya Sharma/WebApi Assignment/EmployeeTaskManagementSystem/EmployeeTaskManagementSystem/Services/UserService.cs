using Microsoft.AspNetCore.Identity;
using TaskManagementSystemApi.DTOs;
using TaskManagementSystemApi.Models;

namespace TaskManagementSystemApi.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = _userManager.Users.ToList();

            var result = new List<UserDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);

                result.Add(new UserDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email!,
                    //Role = roles.FirstOrDefault() ?? "No Role"
                    Roles = roles.ToList()

                });
            }

            return result;
        }

        public async Task<UserDto?> GetUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return null;

            var roles = await _userManager.GetRolesAsync(user);

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email!,
                //Role = roles.FirstOrDefault() ?? "No Role"
                Roles = roles.ToList()
            };
        }
        //new added
        public async Task<bool> AssignRolesAsync(string userId, List<string> roles)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return false;

            var currentRoles = await _userManager.GetRolesAsync(user);

            // Remove existing roles
            await _userManager.RemoveFromRolesAsync(user, currentRoles);

            // Add selected roles
            var result = await _userManager.AddToRolesAsync(user, roles);

            return result.Succeeded;
        }
    }
}

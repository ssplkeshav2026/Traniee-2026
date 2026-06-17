using Microsoft.AspNetCore.Identity;
using TaskManagement.API.DTOs;
using TaskManagement.API.Models;
using TaskManagement.API.Services.Interfaces;

namespace TaskManagement.API.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
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
                    Email = user.Email ?? "",
                 
                    Role = roles != null ? roles.ToList() : new List<string>()
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
                Email = user.Email ?? "",
              
                Role = roles != null ? roles.ToList() : new List<string>()
            };
        }

        public async Task<bool> ChangeRoleAsync(
            string userId,
            string role)
        {
            var user =
                await _userManager.FindByIdAsync(userId);

            if (user == null)
                return false;

            var existingRoles =
                await _userManager.GetRolesAsync(user);

            await _userManager.RemoveFromRolesAsync(
                user,
                existingRoles);

            var result =
                await _userManager.AddToRoleAsync(
                    user,
                    role);

            return result.Succeeded;
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            var user =
                await _userManager.FindByIdAsync(userId);

            if (user == null)
                return false;

            var result =
                await _userManager.DeleteAsync(user);

            return result.Succeeded;
        }
    }
}
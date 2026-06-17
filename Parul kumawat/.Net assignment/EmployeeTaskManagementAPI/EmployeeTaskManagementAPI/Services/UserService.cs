using EmployeeTaskManagementAPI.Data;
using EmployeeTaskManagementAPI.Dto;
using EmployeeTaskManagementAPI.IService;
using EmployeeTaskManagementAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTaskManagementAPI.Services
{
    

    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _context;
        public UserService(UserManager<ApplicationUser> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<List<ApplicationUser>> GetAllUsersAsync()
        {
           
                var users = await _userManager.Users.ToListAsync();
                return users;
            }
           
        

        public async Task<ApplicationUser?> GetUserByIdAsync(string id)
        {

            return await _userManager.FindByIdAsync(id);
        }
            
        

        public async Task<string> DeleteUserAsync(string id)
        {

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return "User not found";

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
                return "Failed to delete user";

            return "User deleted successfully";
        }

        public async Task<string> UpdateUserAsync(UpdateUserDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.Id);

            if (user == null)
            {
                return "User not found";
            }

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.UserName = dto.UserName;
            user.Email = dto.Email;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return string.Join(", ", result.Errors.Select(e => e.Description));

            }
            return "User updated successfully";
        }

    }

    }


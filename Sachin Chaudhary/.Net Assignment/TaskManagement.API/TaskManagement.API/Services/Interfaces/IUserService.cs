using TaskManagement.API.DTOs;
namespace TaskManagement.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(string id);
        Task<bool> ChangeRoleAsync(string userId, string role);
        Task<bool> DeleteUserAsync(string userId);
    }
}

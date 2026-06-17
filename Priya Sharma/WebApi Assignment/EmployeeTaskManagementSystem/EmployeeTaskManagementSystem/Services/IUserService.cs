using TaskManagementSystemApi.DTOs;

namespace TaskManagementSystemApi.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersAsync();

        Task<UserDto> GetUserByIdAsync(string id);
        Task<bool> AssignRolesAsync(string userId, List<string> roles);
    }
}


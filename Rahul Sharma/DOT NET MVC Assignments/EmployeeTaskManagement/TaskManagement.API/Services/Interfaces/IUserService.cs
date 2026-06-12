using TaskManagement.API.DTOs.Users;

namespace TaskManagement.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserResponseDto>> GetAllUsersAsync();

        Task<List<UserResponseDto>> GetEmployeesAsync();

        Task<UserDetailDto> GetUserByIdAsync(string id);

        Task UpdateUserRoleAsync(string id, UpdateUserRoleDto request);

        Task DeleteUserAsync(string id);
    }
}
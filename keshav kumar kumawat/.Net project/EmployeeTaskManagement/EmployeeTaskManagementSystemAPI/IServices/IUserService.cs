using EmployeeTaskManagementSystemAPI.Dto;

namespace EmployeeTaskManagementSystemAPI.IServices
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(string id);
        Task<bool> ChangeUserRoleAsync(string userId, string role);
    }
}

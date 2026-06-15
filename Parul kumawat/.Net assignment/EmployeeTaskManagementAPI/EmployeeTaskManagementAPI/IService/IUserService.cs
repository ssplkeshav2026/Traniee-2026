using EmployeeTaskManagementAPI.Dto;
using EmployeeTaskManagementAPI.Models;

namespace EmployeeTaskManagementAPI.IService
{
    public interface IUserService
    {
        Task<List<ApplicationUser>> GetAllUsersAsync();

        Task<ApplicationUser?> GetUserByIdAsync(string id);

        Task<string> DeleteUserAsync(string id);

        Task<string> UpdateUserAsync(UpdateUserDto dto);

    }
}

using EmployeeTaskManagementSystemMVC.ViewModels;

namespace EmployeeTaskManagementSystemMVC.IServices
{
    public interface IUserService
    {
        Task<List<UserVM>> GetUsersAsync();
        Task<UserVM?> GetUserByIdAsync(string id);
        Task<bool> ChangeUserRoleAsync(string userId, string role);
    }
}

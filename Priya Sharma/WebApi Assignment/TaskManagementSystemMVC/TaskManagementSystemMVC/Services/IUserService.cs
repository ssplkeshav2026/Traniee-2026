using TaskManagementSystemMVC.ViewModel;

namespace TaskManagementSystemMVC.Services
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetAllUsersAsync();
        Task UpdateRolesAsync(string userId, List<string> roles);
    }
}

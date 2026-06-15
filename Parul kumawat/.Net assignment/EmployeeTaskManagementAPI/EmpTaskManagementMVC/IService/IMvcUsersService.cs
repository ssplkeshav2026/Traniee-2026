using EmpTaskManagementMVC.ViewModel.Users;

namespace EmpTaskManagementMVC.IService
{
    public interface IMvcUsersService
    {
        Task<List<UsersViewModel>> GetAllUsersAsync();
        Task<UsersViewModel> GetUserByIdAsync(string id);
        Task<string> DeleteUserAsync(string id);

        Task<string> UpdateUserAsync(UpdateUserViewModel model);

    }
}

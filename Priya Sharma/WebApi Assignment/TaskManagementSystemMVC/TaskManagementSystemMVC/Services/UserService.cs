using TaskManagementSystemMVC.Helper;
using TaskManagementSystemMVC.ViewModel;

namespace TaskManagementSystemMVC.Services
{
    public class UserService : IUserService
    {
        private readonly ApiService _apiService;

        public UserService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<UserViewModel>> GetAllUsersAsync()
        {
            return await _apiService.GetAsync<List<UserViewModel>>("api/User")?? new List<UserViewModel>();
        }

        public async Task UpdateRolesAsync(string userId, List<string> roles)
        {
            await _apiService.PutAsync(
                $"api/User/assign-roles/{userId}",
                roles);
        }
    }
}

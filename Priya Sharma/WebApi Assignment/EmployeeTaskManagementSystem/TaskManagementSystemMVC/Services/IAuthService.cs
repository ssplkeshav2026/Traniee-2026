using TaskManagementSystemMVC.ViewModel;

namespace TaskManagementSystemMVC.Services
{
    public interface IAuthService
    {
        Task<(bool success, string accessToken, string refreshToken,string error)> LoginAsync(LoginViewModel model);

        Task<(bool success, string error)> RegisterAsync(RegisterViewModel model);
    }
}

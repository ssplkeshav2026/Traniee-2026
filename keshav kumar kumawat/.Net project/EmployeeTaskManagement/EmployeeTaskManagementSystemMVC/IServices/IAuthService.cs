using EmployeeTaskManagementSystemMVC.ViewModels;

namespace EmployeeTaskManagementSystemMVC.IServices
{
    public interface IAuthService
    {
        Task<AuthResponseVM?> LoginAsync(LoginVM model);
        Task<bool> RegisterAsync(RegisterVM model);
        Task<bool> LogoutAsync();

        void SaveTokens(AuthResponseVM token);
        string? GetAccessToken();
        string? GetRefreshToken();
        void ClearTokens();

        bool IsLoggedIn();
        string? GetRole();
        Task<bool> RefreshAccessTokenAsync();
    }
}

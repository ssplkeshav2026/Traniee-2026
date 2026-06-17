using EmpTaskManagementMVC.ViewModel;

namespace EmpTaskManagementMVC.IService
{
    public interface IMvcAuthService
    {
        Task<bool> RegisterAsync(RegisterViewModel model);

        Task<LoginTokenResponseViewModel> LoginAsync(LoginViewModel model);
        Task<LoginTokenResponseViewModel> RefreshTokenAsync(string refreshToken);

        Task<string> LogoutAsync(string refreshToken);

        Task<DateTime?> GetAccessTokenExpireTime(string accessToken); 

    }
}

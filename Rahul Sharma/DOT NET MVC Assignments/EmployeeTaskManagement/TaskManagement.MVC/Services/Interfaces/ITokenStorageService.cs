


using TaskManagement.MVC.ViewModels.Auth;

namespace TaskManagement.MVC.Services.Interfaces
{
    public interface ITokenStorageService
    {
        void StoreTokens(string accessToken, string refreshToken, int expiresIn);

        string? GetAccessToken();

        string? GetRefreshToken();

        DateTime? GetAccessTokenExpiry();

        bool IsAccessTokenExpired();

        UserSessionViewModel? GetLoggedInUser();

        void ClearTokens();
    }
}
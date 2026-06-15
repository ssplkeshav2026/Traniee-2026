using System.Threading.Tasks;

namespace TaskManagement.MVC.Interfaces
{
    public interface ITokenService
    {
        Task SetTokens(string accessToken, string refreshToken);
        Task<string?> GetAccessToken();
        Task<string?> GetRefreshToken();
        Task ClearTokens();
    }
}
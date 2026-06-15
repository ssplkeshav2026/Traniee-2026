using TaskManagementSystemApi.Models;

namespace TaskManagementSystemApi.Services
{
    public interface IRefreshTokenService
    {
        Task<RefreshToken> CreateRefreshTokenAsync(string userId);

        Task<RefreshToken?> GetRefreshTokenAsync(string token);

        Task RevokeRefreshTokenAsync(string token);
    }
}

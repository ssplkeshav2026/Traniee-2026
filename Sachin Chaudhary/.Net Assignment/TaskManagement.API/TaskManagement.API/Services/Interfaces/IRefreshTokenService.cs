using TaskManagement.API.Models;

namespace TaskManagement.API.Services.Interfaces
{
    public interface IRefreshTokenService
    {
        string GenerateRefreshToken();

        Task<RefreshToken> SaveRefreshToken(
            string userId,
            string token);
    }
}
using EmployeeTaskManagementSystemAPI.Models;

namespace EmployeeTaskManagementSystemAPI.IServices
{
    public interface IRefreshTokenService
    {
        Task<RefreshToken> CreateRefreshTokenAsync(string userId);
        Task<RefreshToken?> GetRefreshTokenAsync(string token);
        Task RevokeRefreshTokenAsync(RefreshToken refreshToken);
    }
}

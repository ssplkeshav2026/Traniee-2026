using TaskManagement.API.Models;

namespace TaskManagement.API.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateAccessTokenAsync(ApplicationUser user);
        string GenerateRefreshToken();
    }
}
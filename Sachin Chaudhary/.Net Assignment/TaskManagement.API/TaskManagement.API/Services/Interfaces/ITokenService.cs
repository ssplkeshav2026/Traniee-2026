using TaskManagement.API.Models;

namespace TaskManagement.API.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateAccessToken(ApplicationUser user);
    }
}

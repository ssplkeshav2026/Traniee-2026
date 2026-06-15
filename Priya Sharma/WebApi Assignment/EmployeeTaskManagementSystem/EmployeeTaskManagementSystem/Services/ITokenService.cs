using TaskManagementSystemApi.Models;

namespace TaskManagementSystemApi.Services
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAsync(ApplicationUser user);

    }
}

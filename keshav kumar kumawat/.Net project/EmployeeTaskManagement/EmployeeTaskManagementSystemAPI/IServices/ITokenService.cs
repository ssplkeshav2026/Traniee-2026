using EmployeeTaskManagementSystemAPI.Models;

namespace EmployeeTaskManagementSystemAPI.IServices
{
    public interface ITokenService
    {
        Task<string> GenerateAccessTokenAsync(ApplicationUser user);
        string GenerateRefreshToken();
    }
}

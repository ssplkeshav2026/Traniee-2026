using EmployeeTaskManagementAPI.Dto;
using EmployeeTaskManagementAPI.Models;

namespace EmployeeTaskManagementAPI.IService
{
    public interface ITokenService
    {
        string GenerateRefreshToken();
        Task<string> GenerateAccessTokenAsync(ApplicationUser user);
    }
}

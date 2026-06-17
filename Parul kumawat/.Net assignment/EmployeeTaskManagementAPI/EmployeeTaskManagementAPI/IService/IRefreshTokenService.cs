using EmployeeTaskManagementAPI.Dto;

namespace EmployeeTaskManagementAPI.IService
{
    public interface IRefreshTokenService
    {
        Task<string> LogoutAsync(RefreshTokenDto refreshTokenDto);
        Task SaveRefreshTokenAsync(string userId, string token);

        Task<TokenResponseDto> RotateRefreshToken(string token);
    }
}

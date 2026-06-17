using EmployeeTaskManagementAPI.Dto;

namespace EmployeeTaskManagementAPI.IService
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDto dto);
        Task<TokenResponseDto> LoginAsync(LoginDto dto);
        //Task<TokenResponseDto> RefreshTokenAsync(string refreshToken);
        //Task LogoutAsync(string refreshToken);
    }
}

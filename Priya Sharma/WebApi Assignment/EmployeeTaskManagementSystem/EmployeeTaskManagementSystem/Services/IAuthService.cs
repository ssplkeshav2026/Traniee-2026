using TaskManagementSystemApi.DTOs;

namespace TaskManagementSystemApi.Services
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterDto dto);

        Task<AuthDto> LoginAsync(LoginDto dto);

        Task<AuthDto> RefreshTokenAsync(string refreshToken);

        Task LogoutAsync(string refreshToken);

    }
}

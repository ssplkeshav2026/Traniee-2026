
using TaskManagement.API.DTOs;

public interface IAuthService
{
    Task<AuthResult> RegisterAsync(RegisterDto dto);

    Task<AuthResult> LoginAsync(LoginDto dto);

    Task<AuthResult> RefreshTokenAsync(string refreshToken);

    Task<bool> LogoutAsync(string refreshToken);
}
using EmployeeTaskManagementSystemAPI.Dto;
using EmployeeTaskManagementSystemAPI.IServices;
using EmployeeTaskManagementSystemAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace EmployeeTaskManagementSystemAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IRefreshTokenService _refreshTokenService;

        public AuthService(UserManager<ApplicationUser> userManager,ITokenService tokenService,IRefreshTokenService refreshTokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _refreshTokenService = refreshTokenService;
        }

        public async Task<string> RegisterAsync(RegisterDto dto)
        {
            var user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                Firstname = dto.FirstName,
                Lastname = dto.LastName
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                return string.Join(", ",
                    result.Errors.Select(x => x.Description));
            }

            await _userManager.AddToRoleAsync(user, "Employee");

            return "User Registered Successfully";
        }

        public async Task<AuthResponseDto?> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null)
                return null;

            var isPasswordValid =
                await _userManager.CheckPasswordAsync(user, dto.Password);

            if (!isPasswordValid)
                return null;

            var accessToken = await _tokenService.GenerateAccessTokenAsync(user);

            var refreshToken =await _refreshTokenService.CreateRefreshTokenAsync(user.Id);

            return new AuthResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token,
                ExpiresIn = 1800
            };
        }

        public async Task<AuthResponseDto> RefreshTokenAsync(string refreshToken)
        {
            var oldToken = await _refreshTokenService.GetRefreshTokenAsync(refreshToken);

            if (oldToken == null || !oldToken.IsActive)
                throw new Exception("Invalid refresh token");

            await _refreshTokenService.RevokeRefreshTokenAsync(oldToken);

            var user = await _userManager.FindByIdAsync(oldToken.UserId);

            if (user == null)
                throw new Exception("User not found");

            var newAccessToken = await _tokenService.GenerateAccessTokenAsync(user);

            var newRefreshToken = await _refreshTokenService.CreateRefreshTokenAsync(user.Id);

            return new AuthResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken.Token,
                ExpiresIn = 1800
            };
        }

        public async Task<bool> LogoutAsync(string refreshToken)
        {
            var token = await _refreshTokenService.GetRefreshTokenAsync(refreshToken);

            if (token == null)
                return false;

            await _refreshTokenService.RevokeRefreshTokenAsync(token);

            return true;
        }
    }

}

using Microsoft.AspNetCore.Identity;
using TaskManagementSystemApi.DTOs;
using TaskManagementSystemApi.Models;

namespace TaskManagementSystemApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IRefreshTokenService _refreshTokenService;

        public AuthService(UserManager<ApplicationUser> userManager,
            ITokenService tokenService,
            IRefreshTokenService refreshTokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _refreshTokenService = refreshTokenService;
        }

        public async Task RegisterAsync(RegisterDto dto)
        {
            var user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };

            var result =
                await _userManager.CreateAsync(
                    user,
                    dto.Password);

            if (!result.Succeeded)
            {
                throw new Exception(
                    string.Join(",",
                    result.Errors.Select(x => x.Description)));
            }

            await _userManager.AddToRoleAsync(
                user,
                "Employee");
        }

        public async Task<AuthDto> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null)
            {
                throw new Exception("Invalid Credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user,dto.Password);

            if (!isPasswordValid)
            {
                throw new Exception("Invalid Credentials");
            }

            var accessToken = await _tokenService.GenerateTokenAsync(user);

            var refreshToken = await _refreshTokenService.CreateRefreshTokenAsync(user.Id);

            return new AuthDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token,
                ExpiresIn = 1800
            };
        }

        public async Task<AuthDto>RefreshTokenAsync(string refreshToken)
        {
            var existingToken = await _refreshTokenService.GetRefreshTokenAsync(refreshToken);

            if (existingToken == null)
            {
                throw new Exception("Invalid Refresh Token");
            }

            await _refreshTokenService.RevokeRefreshTokenAsync(refreshToken);

            var user =await _userManager.FindByIdAsync(existingToken.UserId);

            var newAccessToken =await _tokenService.GenerateTokenAsync(user);

            var newRefreshToken =await _refreshTokenService.CreateRefreshTokenAsync(user.Id);

            return new AuthDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken.Token,
                ExpiresIn = 1800
            };
        }

        public async Task LogoutAsync(string refreshToken)
        {
            await _refreshTokenService.RevokeRefreshTokenAsync(refreshToken);
        }
    }
}

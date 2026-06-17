using Microsoft.AspNetCore.Identity;
using TaskManagement.API.DTOs.Auth;
using TaskManagement.API.Models;
using TaskManagement.API.Services.Interfaces;
using TaskManagement.API.Helpers.Exceptions;

namespace TaskManagement.API.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IRefreshTokenService _refreshTokenService;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            ITokenService tokenService,
            IRefreshTokenService refreshTokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _refreshTokenService = refreshTokenService;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);

            if (existingUser != null)
                throw new BadRequestException("User already exists.");

            var user = new ApplicationUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.Email,
                Email = request.Email
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new BadRequestException(errors);
            }

            await _userManager.AddToRoleAsync(user, "Employee");

            var accessToken = await _tokenService.GenerateAccessTokenAsync(user);
            var refreshToken = await _refreshTokenService.CreateRefreshTokenAsync(user.Id);

            return new AuthResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token,
                ExpiresIn = 1800  //30 mint
            };
        }

        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
                throw new UnauthorizedException("Invalid email or password.");

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isPasswordValid)
                throw new UnauthorizedException("Invalid email or password.");

            var accessToken = await _tokenService.GenerateAccessTokenAsync(user);
            var refreshToken = await _refreshTokenService.CreateRefreshTokenAsync(user.Id);

            return new AuthResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token,
                ExpiresIn = 1800
            };
        }

        public async Task<AuthResponseDto> RefreshTokenAsync(RefreshTokenRequestDto request)
        {
            var oldRefreshToken =
                await _refreshTokenService.GetRefreshTokenAsync(request.RefreshToken);

            if (oldRefreshToken == null ||
                !oldRefreshToken.IsActive ||
                oldRefreshToken.User == null)
            {
                throw new UnauthorizedException("Invalid or expired refresh token.");
            }

            await _refreshTokenService.RevokeRefreshTokenAsync(oldRefreshToken);

            var newAccessToken =
                await _tokenService.GenerateAccessTokenAsync(oldRefreshToken.User);

            var newRefreshToken =
                await _refreshTokenService.CreateRefreshTokenAsync(oldRefreshToken.UserId);

            return new AuthResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken.Token,
                ExpiresIn = 1800
            };
        }

        public async Task LogoutAsync(LogoutRequestDto request)
        {
            var refreshToken =
                await _refreshTokenService.GetRefreshTokenAsync(request.RefreshToken);

            if (refreshToken == null)
                throw new NotFoundException("Refresh token not found.");

            if (refreshToken.IsActive)
            {
                await _refreshTokenService.RevokeRefreshTokenAsync(refreshToken);
            }
        }
    }
}

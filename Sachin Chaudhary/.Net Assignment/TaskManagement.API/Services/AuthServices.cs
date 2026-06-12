using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using TaskManagement.API.DTOs;
using TaskManagement.API.Models;
using TaskManagement.API.Services.Interfaces;


namespace TaskManagement.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly ITokenService _tokenService;

        private readonly IRefreshTokenService _refreshTokenService;

        private readonly ApplicationDbContext _context;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ITokenService tokenService,
            IRefreshTokenService refreshTokenService,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _refreshTokenService = refreshTokenService;
            _context = context;
        }

        public async Task<AuthResult> RegisterAsync(
            RegisterDto dto)
        {
            var user = new ApplicationUser
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                UserName = dto.Email
            };

            var result =
                await _userManager.CreateAsync(
                    user,
                    dto.Password);

            if (!result.Succeeded)
            {
                return new AuthResult
                {
                    Success = false,
                    Message = string.Join(",",
                    result.Errors.Select(x => x.Description))
                };
            }

            await _userManager.AddToRoleAsync(
                user,
                "Employee");

            return new AuthResult
            {
                Success = true,
                Message = "User Registered Successfully"
            };
        }

        public async Task<AuthResult> LoginAsync(
            LoginDto dto)
        {
            var user =
                await _userManager.FindByEmailAsync(
                    dto.Email);

            if (user == null)
                return null;

            var result =
                await _signInManager
                .CheckPasswordSignInAsync(
                    user,
                    dto.Password,
                    false);

            if (!result.Succeeded)
                return null;

            var accessToken =
                await _tokenService
                .GenerateAccessToken(user);

            var refreshToken =
                _refreshTokenService
                .GenerateRefreshToken();

            await _refreshTokenService
                .SaveRefreshToken(
                    user.Id,
                    refreshToken);

            return new AuthResult
            {
                Success = true,
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresIn = 1800
            };
        }

        public async Task<AuthResult> RefreshTokenAsync(string refreshToken)
        {
            var existingToken =
                await _context.RefreshTokens
                .FirstOrDefaultAsync(x =>
                    x.Token == refreshToken &&
                    x.IsActive);

            if (existingToken == null)
                return null;

            if (existingToken.ExpiresAt < DateTime.UtcNow)
                return null;

            // OLD TOKEN REVOKE
            existingToken.IsActive = false;
            existingToken.RevokedAt = DateTime.UtcNow;

            _context.RefreshTokens.Update(existingToken);

            await _context.SaveChangesAsync();

            var user =
                await _userManager.FindByIdAsync(
                    existingToken.UserId);

            // NEW ACCESS TOKEN
            var accessToken =
                await _tokenService.GenerateAccessToken(user);

            // NEW REFRESH TOKEN
            var newRefreshToken =
                _refreshTokenService.GenerateRefreshToken();

            await _refreshTokenService.SaveRefreshToken(
                user.Id,
                newRefreshToken);

            return new AuthResult
            {
                Success = true,
                AccessToken = accessToken,
                RefreshToken = newRefreshToken,
                ExpiresIn = 1800
            };
        }
        public async Task<bool> LogoutAsync(
            string refreshToken)
        {
            var token =
                await _context.RefreshTokens
                .FirstOrDefaultAsync(x =>
                    x.Token == refreshToken);

            if (token == null)
                return false;

            token.IsActive = false;

            token.RevokedAt =
                DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
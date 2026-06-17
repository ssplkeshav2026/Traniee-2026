using EmployeeTaskManagementAPI.Dto;
using EmployeeTaskManagementAPI.Models;
using EmployeeTaskManagementAPI.IService;

using Microsoft.AspNetCore.Identity;
using EmployeeTaskManagementAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTaskManagementAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IRefreshTokenService _refreshTokenService;
        public AuthService(UserManager<ApplicationUser> userManager, ITokenService tokenService, IRefreshTokenService refreshTokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _refreshTokenService = refreshTokenService;
        }
        public async Task<string> RegisterAsync(RegisterDto dto)
        {
            
                var isExist = _userManager.Users.FirstOrDefault(x => x.Email == dto.Email);
                if (isExist != null)
                {
                    return "User is already exist of this email";

                }
                var user = new ApplicationUser
                {
                    UserName = dto.Email,
                    Email = dto.Email,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,

                };
                var result = await _userManager.CreateAsync(user, dto.Password);
                if (!result.Succeeded)
                {
                    return string.Join(", ", result.Errors.Select(x => x.Description));

                }
                return "User registered successfully";

            
           

        }
        public async Task<TokenResponseDto> LoginAsync(LoginDto loginDto)
        {
               var user = _userManager.Users.FirstOrDefault(x => x.Email == loginDto.Email);
            
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                var checkPass = await _userManager.CheckPasswordAsync(user, loginDto.Password);
                if (!checkPass)
                {
                    throw new Exception("Invalid Password");

                }
                var accessToken = await _tokenService.GenerateAccessTokenAsync(user);
                var refreshToken = _tokenService.GenerateRefreshToken();
                await _refreshTokenService.SaveRefreshTokenAsync(user.Id, refreshToken);

                return new TokenResponseDto
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    ExpiresIn = 1800
               };
            
            
        }



    }
}


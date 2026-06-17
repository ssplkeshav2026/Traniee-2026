using Microsoft.EntityFrameworkCore;
using EmployeeTaskManagementAPI.Dto;
using EmployeeTaskManagementAPI.IService;
using EmployeeTaskManagementAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace EmployeeTaskManagementAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        public TokenService( IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }


        public string GenerateRefreshToken()
        {
            var randomNum = new Byte[64];
            using var num = RandomNumberGenerator.Create();
            num.GetBytes(randomNum);
            return Convert.ToBase64String(randomNum);
        }


        public async Task<string> GenerateAccessTokenAsync(ApplicationUser user)
        {
            
                if (user == null)
                {
                    throw new Exception("User not found");
                }
            
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email ?? ""),
                    new Claim(ClaimTypes.Name, user.UserName ??""),

                };
                var roles = await _userManager.GetRolesAsync(user);

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddSeconds(20),
                    signingCredentials: signIn
                    );
                string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
                return tokenValue;
            }
            
           
        }
    }



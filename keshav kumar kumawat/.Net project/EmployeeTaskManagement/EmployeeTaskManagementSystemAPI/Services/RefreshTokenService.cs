using EmployeeTaskManagementSystemAPI.Data;
using EmployeeTaskManagementSystemAPI.IServices;
using EmployeeTaskManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTaskManagementSystemAPI.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly AppDbContext _context;
        private readonly ITokenService _tokenService;

        public RefreshTokenService(AppDbContext context,ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<RefreshToken> CreateRefreshTokenAsync(string userId)
        {
            var refreshToken = new RefreshToken
            {
                UserId = userId,
                Token = _tokenService.GenerateRefreshToken(),
                CreatedAt = DateTime.Now,
                ExpiresAt = DateTime.Now.AddDays(7)
            };

            _context.RefreshTokens.Add(refreshToken);
            await _context.SaveChangesAsync();

            return refreshToken;
        }

        public async Task<RefreshToken?> GetRefreshTokenAsync(string token)
        {
            return await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Token == token);
        }

        public async Task RevokeRefreshTokenAsync(RefreshToken refreshToken)
        {
            refreshToken.RevokedAt = DateTime.Now;
            await _context.SaveChangesAsync();
        }
    }
}

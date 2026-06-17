using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using TaskManagementSystemApi.Data;
using TaskManagementSystemApi.Models;

namespace TaskManagementSystemApi.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly ApplicationDbContext _context;

        public RefreshTokenService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RefreshToken> CreateRefreshTokenAsync(string userId)
        {
            var refreshToken = new RefreshToken
                {
                    UserId = userId,
                    Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                    CreatedAt = DateTime.UtcNow,
                    ExpiresAt = DateTime.UtcNow.AddDays(7),
                    IsActive = true
                };

            await _context.RefreshTokens.AddAsync(refreshToken);

            await _context.SaveChangesAsync();

            return refreshToken;
        }

        public async Task<RefreshToken?> GetRefreshTokenAsync(string token)
        {
            return await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Token == token && x.IsActive && x.ExpiresAt > DateTime.UtcNow);
        }

        public async Task RevokeRefreshTokenAsync(string token)
        {
            //var existing = await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Token == token);

            //if (refreshToken == null)
            //    return;

            //refreshToken.IsActive = false;
            //refreshToken.RevokedAt = DateTime.UtcNow;

            //await _context.SaveChangesAsync();
            var existing = await _context.RefreshTokens.FirstOrDefaultAsync(t => t.Token == token);

            if (existing == null)
                return;

            _context.RefreshTokens.Remove(existing);
            await _context.SaveChangesAsync();
        }
        

    }
}

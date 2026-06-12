using System.Security.Cryptography;

using TaskManagement.API.Models;
using TaskManagement.API.Services.Interfaces;

public class RefreshTokenService : IRefreshTokenService
{
    private readonly ApplicationDbContext _context;

    public RefreshTokenService(ApplicationDbContext context)
    {
        _context = context;
    }

    public string GenerateRefreshToken()
    {
        var randomBytes = new byte[64];

        using var rng = RandomNumberGenerator.Create();

        rng.GetBytes(randomBytes);

        return Convert.ToBase64String(randomBytes);
    }

    public async Task<RefreshToken> SaveRefreshToken(
        string userId,
        string token)
    {
        var refreshToken = new RefreshToken
        {
            UserId = userId,
            Token = token,
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.AddDays(7),
            IsActive = true
        };

        _context.RefreshTokens.Add(refreshToken);

        await _context.SaveChangesAsync();

        return refreshToken;
    }
}
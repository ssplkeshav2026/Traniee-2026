

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TaskManagement.MVC.Services.Interfaces;
using TaskManagement.MVC.ViewModels.Auth;

namespace TaskManagement.MVC.Services.Implementations
{
    public class TokenStorageService : ITokenStorageService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenStorageService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void StoreTokens(string accessToken, string refreshToken, int expiresIn)
        {
            var session = _httpContextAccessor.HttpContext!.Session;

            session.SetString("AccessToken", accessToken);
            session.SetString("RefreshToken", refreshToken);
            session.SetString("AccessTokenExpiry", DateTime.UtcNow.AddSeconds(expiresIn).ToString("O"));
        }

        public string? GetAccessToken()
        {
            return _httpContextAccessor.HttpContext!.Session.GetString("AccessToken");
        }

        public string? GetRefreshToken()
        {
            return _httpContextAccessor.HttpContext!.Session.GetString("RefreshToken");
        }

        public DateTime? GetAccessTokenExpiry()
        {
            var expiry = _httpContextAccessor.HttpContext!.Session.GetString("AccessTokenExpiry");

            if (string.IsNullOrEmpty(expiry))
                return null;

            return DateTime.Parse(expiry);
        }

        public bool IsAccessTokenExpired()
        {
            var expiry = GetAccessTokenExpiry();

            if (expiry == null)
                return true;

            return DateTime.UtcNow >= expiry.Value.AddMinutes(-1);
        }
        public UserSessionViewModel? GetLoggedInUser()
        {
            var token = GetAccessToken();

            if (string.IsNullOrEmpty(token))
                return null;

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var userId = jwtToken.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value ?? string.Empty;

            var email = jwtToken.Claims.FirstOrDefault(c =>
                c.Type == ClaimTypes.Email ||
                c.Type == "email")?.Value ?? string.Empty;

            var role = jwtToken.Claims.FirstOrDefault(c =>
                c.Type == ClaimTypes.Role ||
                c.Type == "role")?.Value ?? string.Empty;

            return new UserSessionViewModel
            {
                UserId = userId,
                Email = email,
                Role = role
            };
        }
        public void ClearTokens()
        {
            _httpContextAccessor.HttpContext!.Session.Clear();
        }
    }
}
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using TaskManagement.MVC.Interfaces;

namespace TaskManagement.MVC.Services
{
    public class TokenService : ITokenService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Task SetTokens(string accessToken, string refreshToken)
        {
            var context = _httpContextAccessor.HttpContext;
            if (context != null)
            {
                context.Response.Cookies.Delete("AccessToken");
                context.Response.Cookies.Delete("RefreshToken");

                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = false, 
                    SameSite = SameSiteMode.Lax,
                    Expires = DateTimeOffset.UtcNow.AddHours(12)
                };

                context.Response.Cookies.Append("AccessToken", accessToken, cookieOptions);

                context.Response.Cookies.Append("RefreshToken", refreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = false,
                    SameSite = SameSiteMode.Lax,
                    Expires = DateTimeOffset.UtcNow.AddDays(7)
                });
            }

            return Task.CompletedTask;
        }

        public Task<string?> GetAccessToken()
        {
            var token = _httpContextAccessor.HttpContext?.Request.Cookies["AccessToken"];
            return Task.FromResult(token);
        }

        public Task<string?> GetRefreshToken()
        {
            var token = _httpContextAccessor.HttpContext?.Request.Cookies["RefreshToken"];
            return Task.FromResult(token);
        }

        public Task ClearTokens()
        {
            var context = _httpContextAccessor.HttpContext;
            if (context != null)
            {
                context.Response.Cookies.Delete("AccessToken");
                context.Response.Cookies.Delete("RefreshToken");
            }

            return Task.CompletedTask;
        }
    }
}
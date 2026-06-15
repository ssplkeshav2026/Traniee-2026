using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace TaskManagementSystemMVC.Middelware
{
    public class TokenRefreshMiddeware
    {
        private readonly RequestDelegate _next;

        public TokenRefreshMiddeware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Skip for public pages and static files
            var path = context.Request.Path.Value?.ToLower();
            if (ShouldSkip(path))
            {
                await _next(context);
                return;
            }

            // Skip if not logged in
            if (context.User.Identity?.IsAuthenticated != true)
            {
                await _next(context);
                return;
            }

            var accessToken = context.Request.Cookies["access_token"];

            // If access token is expiring soon (refresh it)
            if (!string.IsNullOrEmpty(accessToken) && IsExpiringSoon(accessToken))
            {
                var success = await RefreshTokensAsync(context);

                if (!success)
                {
                   
                    context.Response.Cookies.Delete("access_token");
                    context.Response.Cookies.Delete("refresh_token");
                    context.Response.Redirect("/Auth/Login");
                    return;
                }
            }

            await _next(context);
        }

        // Pages that do not need token check
        private bool ShouldSkip(string? path)
        {
            if (path == null) return false;

            return path.Contains("/auth/login") ||
                   path.Contains("/auth/register") ||
                   path.Contains("/auth/logout") ||
                   path.Contains("/css") ||
                   path.Contains("/js") ||
                   path.Contains("/lib");
        }

        // Returns true if token expires within 2 minutes
        private bool IsExpiringSoon(string token)
        {
            try
            {
                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
                return jwt.ValidTo < DateTime.UtcNow.AddMinutes(2);
            }
            catch
            {
                return true;
            }
        }

        // Calls API to get new access + refresh token
        private async Task<bool> RefreshTokensAsync(HttpContext context)
        {
            var refreshToken = context.Request.Cookies["refresh_token"];

            if (string.IsNullOrEmpty(refreshToken))
                return false;

            try
            {
                var config = context.RequestServices
                                  .GetRequiredService<IConfiguration>();
                var baseUrl = config["ApiSettings:BaseUrl"];

                using var client = new HttpClient();

                var content = new StringContent(
                    JsonConvert.SerializeObject(new { refreshToken }),
                    Encoding.UTF8,
                    "application/json");

                var response = await client.PostAsync(
                    $"{baseUrl}/api/Auth/refresh-token", content);

                if (!response.IsSuccessStatusCode)
                    return false;

                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeAnonymousType(json,
                    new { accessToken = "", refreshToken = "" });

                if (result == null ||
                    string.IsNullOrEmpty(result.accessToken))
                    return false;

                // Save new tokens in cookies
                var options = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTimeOffset.UtcNow.AddDays(7)
                };

                context.Response.Cookies.Append(
                    "access_token", result.accessToken, options);
                context.Response.Cookies.Append(
                    "refresh_token", result.refreshToken, options);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

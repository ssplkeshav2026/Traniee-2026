using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;

namespace TaskManagementSystemMVC.Helper
{
    public static class TokenHelper
    {
        public static void SetTokens(HttpResponse response, string accessToken, string refreshToken, bool rememberMe = false)
        {
            var options = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = rememberMe
                          ? DateTimeOffset.UtcNow.AddDays(3)
                          : null
            };
            response.Cookies.Append("access_token", accessToken, options);
            response.Cookies.Append("refresh_token",refreshToken, options);
        }

        public static string? GetAccessToken(HttpRequest request)
        {
            return request.Cookies["access_token"];
        }

        public static string? GetRefreshToken(HttpRequest request)
        {
            return request.Cookies["refresh_token"];
        }

        public static void ClearTokens(HttpResponse response)
        {
            response.Cookies.Delete("access_token");
            response.Cookies.Delete("refresh_token");
        }

        //public static bool IsAccessTokenExpired(HttpRequest request)
        //{
        //    var token = GetAccessToken(request);
        //    if (string.IsNullOrEmpty(token))
        //        return true;

        //    try
        //    {
        //        var handler = new JwtSecurityTokenHandler();
        //        var jwt = handler.ReadJwtToken(token);
        //        // Return true if token expires in less than 1 minute
        //        return jwt.ValidTo < DateTime.UtcNow.AddMinutes(1);
        //    }
        //    catch
        //    {
        //        return true;
        //    }
        //}
    }
}

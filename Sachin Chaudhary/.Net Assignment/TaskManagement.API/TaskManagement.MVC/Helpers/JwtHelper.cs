using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace TaskManagement.MVC.Helpers
{
    internal static class JwtHelper
    {
        public static bool IsExpired(string? token)
        {
            if (string.IsNullOrEmpty(token))
                return true;

            var handler = new JwtSecurityTokenHandler();

            if (!handler.CanReadToken(token))
                return true;

            var jwt = handler.ReadJwtToken(token);
            return jwt == null || jwt.ValidTo < DateTime.UtcNow;
        }

        internal static string? GetClaim(string? token, string claimType)
        {
            if (string.IsNullOrEmpty(token))
                return null;

            var handler = new JwtSecurityTokenHandler();

            if (!handler.CanReadToken(token))
                return null;

            var jwtSecurityToken = handler.ReadJwtToken(token);
            var claim = jwtSecurityToken.Claims.FirstOrDefault(c => c.Type == claimType || c.Type.Split('/').Last() == claimType);

            return claim?.Value;
        }
    }
}
using System.Security.Claims;

namespace TaskManagement.MVC.Services
{
    public class TokenResponse
    {
        public ClaimsIdentity? AccessToken { get; internal set; }
        public ClaimsIdentity? RefreshToken { get; internal set; }
    }
}
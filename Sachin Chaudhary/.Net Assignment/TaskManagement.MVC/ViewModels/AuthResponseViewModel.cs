using System.Security.Claims;

namespace TaskManagement.MVC.ViewModels
{
    public class AuthResponseViewModel
    {
        public bool Success { get; set; }

        public string AccessToken { get; set; } = string.Empty;

        public string RefreshToken { get; set; } = string.Empty;
    

        public string Email { get; set; }
        public int ExpiresIn { get; set; }
        public string Role { get; set; }
        public ClaimsIdentity? UserName { get; internal set; }
    }
}

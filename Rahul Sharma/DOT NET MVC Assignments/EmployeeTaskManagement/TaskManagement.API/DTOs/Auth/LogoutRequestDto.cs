using System.ComponentModel.DataAnnotations;

namespace TaskManagement.API.DTOs.Auth
{
    public class LogoutRequestDto
    {
        [Required]
        public string RefreshToken { get; set; } = string.Empty;
    }
}
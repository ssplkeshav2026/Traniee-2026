using System.ComponentModel.DataAnnotations;
//using TaskManagement.API.Models.Enums;

namespace TaskManagement.API.DTOs.Auth
{
    public class RegisterRequestDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty;
        //public UserRole Role { get; set; } = UserRole.Employee;
    }
}
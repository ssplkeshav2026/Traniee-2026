using System.ComponentModel.DataAnnotations;

namespace TaskManagement.API.DTOs.Users
{
    public class UpdateUserRoleDto
    {
        [Required]
        public string Role { get; set; } = string.Empty;
    }
}   
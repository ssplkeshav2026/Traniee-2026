using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RoleBasedAuth.Models.Domain
{
    public class ApplicationUser :IdentityUser
    {
        [Required]
        public string? Name { get; set; }
        public bool Status { get; set; }

        public string ProfilePicture { get; set; }
    }
}

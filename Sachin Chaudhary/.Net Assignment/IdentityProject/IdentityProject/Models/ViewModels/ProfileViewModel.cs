using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace IdentityProject.Models
{
    public class ProfileViewModel
    {
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string? ExistingProfilePicture { get; set; }

        public IFormFile? ProfilePicture { get; set; }
    }
}
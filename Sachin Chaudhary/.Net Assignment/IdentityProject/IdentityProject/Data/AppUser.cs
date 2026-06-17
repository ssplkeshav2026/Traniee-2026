using Microsoft.AspNetCore.Identity;

namespace IdentityProject.Data
{
    public class AppUser : IdentityUser
    {
        
        public required string? FirstName { get; set; }
        public required string? LastName { get; set; }
        public bool IsActive { get; set; }

    }
}
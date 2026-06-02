using Microsoft.AspNetCore.Identity;

namespace IdentityProject.Data
{
    public class ApplicationUser:IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsActive { get; set; } = true;
        public string? ProfilePicture { get; set; }
    }
}

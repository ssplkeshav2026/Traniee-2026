using Microsoft.AspNetCore.Identity;

namespace identity.Data
{
    public class identityUser : IdentityUser
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public bool IsActive { get; set; }

        public string? ProfilePicture { get; set; }

        public string? Address { get; set; }
    }
}
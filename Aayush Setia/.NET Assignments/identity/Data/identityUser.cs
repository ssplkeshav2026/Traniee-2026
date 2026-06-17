using Microsoft.AspNetCore.Identity;

namespace identity.Data
{
    public class identityUser : IdentityUser
    {
        public bool IsActive { get; set; } = true;

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
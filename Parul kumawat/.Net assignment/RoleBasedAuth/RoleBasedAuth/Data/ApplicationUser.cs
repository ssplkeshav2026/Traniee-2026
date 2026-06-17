using Microsoft.AspNetCore.Identity;

namespace RoleBasedAuth.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public bool Status { get; set; } = true;
    }
}

using Microsoft.AspNetCore.Identity;

namespace IdentityDemo.Models
{
    public class Users:IdentityUser
    {
        public String Name { get; set; }
        public bool Status { get; set; } = true;
        public string? ProfilePicture { get; set; }
    }
}

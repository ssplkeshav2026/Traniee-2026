using Microsoft.AspNetCore.Identity;

namespace TaskManagementSystemApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

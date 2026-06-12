using Microsoft.AspNetCore.Identity;

namespace TaskManagement.API.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public ICollection<EmployeeTask> AssignedTasks { get; set; } = new List<EmployeeTask>();

        public ICollection<EmployeeTask> CreatedTasks { get; set; } = new List<EmployeeTask>();

        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    }
}
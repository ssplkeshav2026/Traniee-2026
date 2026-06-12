using System.ComponentModel.DataAnnotations;

namespace EmployeeTaskManagementSystemMVC.ViewModels
{
    public class UserVM
    {
        public string Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; }
    }
}

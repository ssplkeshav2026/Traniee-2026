using System.ComponentModel.DataAnnotations;

namespace EmpTaskManagementMVC.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = " first name is required")]
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        [Required]

        public string Email { get; set; } = string.Empty;
        [Required]

        public string Password { get; set; } = string.Empty;
    }
}

using System.ComponentModel.DataAnnotations;

namespace RoleBasedAuth.Models.ViewModel
{
    public class ChangePasswordViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        
        public string ConfirmPassword { get; set; }
    }
}

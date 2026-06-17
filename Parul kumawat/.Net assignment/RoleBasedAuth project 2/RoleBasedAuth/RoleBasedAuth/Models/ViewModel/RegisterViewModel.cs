using System.ComponentModel.DataAnnotations;

namespace RoleBasedAuth.Models.ViewModel
{
    public class RegisterViewModel
    {
         [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password" , ErrorMessage = "Password and Confirm Password must be same")]
        public string ConfirmPassword { get; set; }

        public IFormFile? ImageFile { get; set; }
    
}
}

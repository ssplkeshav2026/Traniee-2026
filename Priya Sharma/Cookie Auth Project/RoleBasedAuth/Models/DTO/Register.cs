using System.ComponentModel.DataAnnotations;

namespace RoleBasedAuth.Models.DTO
{
    public class Register
    {

        [Required(ErrorMessage ="Name field is blank")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        public IFormFile? ProfileImage { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace RoleBasedAuth.Models
{
    public class Registration
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public int Age { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]

        [Compare("Password", ErrorMessage = "Password and Confirm Password must be same")]


        public string ConfirmPassword { get; set; }

       public string? Picture { get; set; }
    }
}

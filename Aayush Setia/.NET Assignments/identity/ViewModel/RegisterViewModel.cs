using System.ComponentModel.DataAnnotations;

namespace identity.ViewModel
{
    public class RegisterViewModel
    {
       
        public string? FirstName { get; set; }

        
        public string? LastName { get; set; }

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
    }
}
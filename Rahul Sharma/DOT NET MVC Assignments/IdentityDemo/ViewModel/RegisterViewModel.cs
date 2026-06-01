using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IdentityDemo.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Please enter Name !")]
        public String Name { get; set;  }

        [Required(ErrorMessage = "Please enter Email!")]
        [DisplayName("Email Id")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        [Required(ErrorMessage = "Please enter Password !")]
        [Compare("ConfirmPassword", ErrorMessage = "Password Does not Match")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter Confirm Password !")]
        [DisplayName(" ConFirm Password ")]
        public String ConfirmPassword { get; set;  }
    }
}

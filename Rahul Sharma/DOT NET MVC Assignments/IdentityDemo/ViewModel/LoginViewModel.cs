using Microsoft.AspNetCore.Cors;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace IdentityDemo.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress (ErrorMessage="Please Enter Correct Email")]
        [DisplayName("Enter Id")]
        public String Email { get; set; }

        [Required (ErrorMessage ="Please Enter Password")]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public String Password { get; set; }
       
        
        [DisplayName("Remember Me !")]
        public bool RememberMe{ get; set; }
    }
}

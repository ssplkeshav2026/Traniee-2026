using System.ComponentModel.DataAnnotations;

namespace IdentityProject.Models.ViewModel
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public bool IsActive { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace IdentityDemo.ViewModel
{
    public class EditUserViewModel
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public bool Status { get; set; }

        public string? ExistingImage { get; set; }

        public IFormFile? ProfileImage { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
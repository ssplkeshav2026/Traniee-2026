using Microsoft.AspNetCore.Http;

namespace identity.ViewModel
{
    public class ProfileViewModel
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public IFormFile? ProfileImage { get; set; }

        public string? ExistingImage { get; set; }
    }
}
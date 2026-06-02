namespace RoleBasedAuth.Models.ViewModel
{
    public class EditUserProfileViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public string Email { get; set; }
        public string ExistingImage { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}

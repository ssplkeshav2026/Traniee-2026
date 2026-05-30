namespace RoleBasedAuth.Models.DTO
{
    public class EditProfile
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? ExistingProfilePicture { get; set; }
        public IFormFile? ProfileImage { get; set; }
    }
}

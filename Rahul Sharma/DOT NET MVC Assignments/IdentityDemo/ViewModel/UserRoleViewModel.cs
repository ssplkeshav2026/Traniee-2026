namespace IdentityDemo.ViewModel
{
    public class UserRoleViewModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public bool Status { get; set; }

        public bool Admin { get; set; }
        public bool User { get; set; }
        public bool Manager { get; set; }
        public bool Employee { get; set; }
        public string? ProfilePicture { get; set; }
    }
}
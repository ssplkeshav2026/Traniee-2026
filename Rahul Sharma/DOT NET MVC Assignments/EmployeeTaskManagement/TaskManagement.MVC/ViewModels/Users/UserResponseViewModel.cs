namespace TaskManagement.MVC.ViewModels.Users
{
    public class UserResponseViewModel
    {
        public string Id { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}";

        public string Email { get; set; } = string.Empty;

        public IList<string> Roles { get; set; } = new List<string>();
    }
}
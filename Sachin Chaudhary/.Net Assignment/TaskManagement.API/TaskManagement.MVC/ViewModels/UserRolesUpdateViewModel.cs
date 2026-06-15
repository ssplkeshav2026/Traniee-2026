namespace TaskManagement.MVC.ViewModels
{
    public class UserRolesUpdateViewModel
    {
        public string? UserId { get;  set; }
        public List<string> Roles { get; set; } = new();
    }
}
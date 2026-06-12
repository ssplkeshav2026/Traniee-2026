using Microsoft.AspNetCore.Mvc.Rendering;

namespace TaskManagement.MVC.ViewModels.Users
{
    public class UserDetailsViewModel
    {
        public string Id { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public IList<string> Roles { get; set; } = new List<string>();

        public string SelectedRole { get; set; } = string.Empty;

        public List<SelectListItem> RoleList { get; set; } = new();
    }
}
using System.Collections.Generic;

namespace TaskManagement.MVC.ViewModels
{
    public class UserRolesUpdateViewModel
    {
        public string UserId { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = new();
    }
}
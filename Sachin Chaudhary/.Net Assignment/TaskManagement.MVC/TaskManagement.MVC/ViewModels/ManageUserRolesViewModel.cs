using System.Collections.Generic;

namespace TaskManagement.MVC.ViewModels
{
    public class ManageUserRolesViewModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public List<string> CurrentRoles { get; set; }
        public List<string> AvailableRoles { get; set; }
    }
}
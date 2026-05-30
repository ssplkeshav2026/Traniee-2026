namespace RoleBasedAuth.Models.ViewModel
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public bool Status { get; set; }

        public List<string> Roles { get; set; }

        public List<string> SelectedUsersRoles { get; set; }

    }
}

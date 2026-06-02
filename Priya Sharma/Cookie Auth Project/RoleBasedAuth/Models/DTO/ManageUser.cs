namespace RoleBasedAuth.Models.DTO
{
    public class ManageUser
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public bool Status { get; set; }

        public List<string> UserRoles { get; set; }


    }
}



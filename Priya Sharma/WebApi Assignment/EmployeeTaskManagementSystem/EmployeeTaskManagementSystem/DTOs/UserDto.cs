namespace TaskManagementSystemApi.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string Email { get; set; }
        //public string Role { get; set; } 
        public List<string> Roles { get; set; } = new();

        public string FullName => FirstName + " " + LastName;
    }
}

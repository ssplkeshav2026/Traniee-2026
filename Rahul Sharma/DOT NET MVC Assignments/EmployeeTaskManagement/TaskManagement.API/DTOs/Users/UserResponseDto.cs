//namespace TaskManagement.API.DTOs.Users
//{
//    public class UserDetailDto
//    {
//        public string Id { get; set; } = string.Empty;

//        public string FirstName { get; set; } = string.Empty;

//        public string LastName { get; set; } = string.Empty;

//        public string Email { get; set; } = string.Empty;

//        public IList<string> Roles { get; set; } = new List<string>();
//    }
//}


namespace TaskManagement.API.DTOs.Users
{
    public class UserResponseDto
    {
        public string Id { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}";

        public string Email { get; set; } = string.Empty;

        public IList<string> Roles { get; set; } = new List<string>();
    }
}
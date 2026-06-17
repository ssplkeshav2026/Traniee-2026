using System.ComponentModel.DataAnnotations;

namespace TaskManagement.API.DTOs
{
    public class UserDto
    {
        public string Id { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "The role field is required.")]
        public List<string> Role { get; set; }



    }
}

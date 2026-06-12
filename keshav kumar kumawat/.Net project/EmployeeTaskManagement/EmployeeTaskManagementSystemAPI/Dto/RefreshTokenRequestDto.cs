using System.ComponentModel.DataAnnotations;

namespace EmployeeTaskManagementSystemAPI.Dto
{
    public class RefreshTokenRequestDto
    {
        [Required]
        public string RefreshToken { get; set; }

    }
}

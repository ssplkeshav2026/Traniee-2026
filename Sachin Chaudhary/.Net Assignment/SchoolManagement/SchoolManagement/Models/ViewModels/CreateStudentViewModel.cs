using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.ViewModels
{
    public class CreateStudentViewModel
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? Fname { get; set; }

        [Required]
        public string? Lname { get; set; }

        [Required]
        public DateOnly? Dob { get; set; }

        [Required]
        public string? Phone { get; set; }

        public string? Mobile { get; set; }

        public int? ParentId { get; set; }

        [Required]
        public DateOnly? DateOfJoin { get; set; }

        public bool? Status { get; set; }

        public DateOnly? LastLoginDate { get; set; }

        public string? LastLoginIp { get; set; }

        public virtual Parent? Parent { get; set; }
    }
}

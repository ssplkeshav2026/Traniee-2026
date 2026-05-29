using First.netAssigmnet.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace First.netAssigmnet.ViewModel
{
    public class StudentViewModel
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]

        public string? Fname { get; set; }

        public string? Lname { get; set; }
        [Required]

        public DateOnly? Dob { get; set; }
        [Required]

        public string? Phone { get; set; }

        public string? Mobile { get; set; }
        [Required]

        public int? ParentId { get; set; }

        public DateOnly? DateOfJoin { get; set; }

        public bool? Status { get; set; }

        public DateOnly? LastLoginDate { get; set; }

        public string? LastLoginIp { get; set; }

        public List<Parent>? Parents { get; set; } = default;

        public virtual Parent? Parent { get; set; }

        public virtual Classroom? Classroom { get; set; }


    }
}

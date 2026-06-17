
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolManagementSystem.ViewModels
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }

        public string? Email { get; set; }

        public string? Passwordd { get; set; }

        public string? Fname { get; set; }

        public string? Lname { get; set; }

        public DateOnly? Dob { get; set; }

        public string? Phone { get; set; }

        public string? Mobile { get; set; }

        public int? ParentId { get; set; }

        public bool? Status { get; set; }

        public DateOnly? LastLoginDate { get; set; }

        public string? LastLoginIp { get; set; }

        public List<SelectListItem>? ParentList { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.ViewModels
{
    public class ExamViewModel
    {
        public int ExamId { get; set; }

        [Required]
        public int? ExamTypeId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public DateOnly? StartDate { get; set; }
    }
}
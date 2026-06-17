using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.ViewModels
{
    public class ExamResultViewModel
    {
        [Required]
        public int? ExamId { get; set; }

        [Required]
        public int? StudentId { get; set; }

        [Required]
        public int? CourceId { get; set; }

        [Required]
        public string? Marks { get; set; }
    }
}
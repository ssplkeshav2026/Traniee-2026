using First.netAssigmnet.Models;
using System.ComponentModel.DataAnnotations;

namespace First.netAssigmnet.ViewModel
{
    public class ExamResultViewModel
    {
        [Required]
        public int? ExamId { get; set; }

        [Required]
        public int? StudentId { get; set; }

        [Required]
        public int? CourseId { get; set; }

        [Required]
        public string? Marks { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Exam? Exam { get; set; }
        public virtual Student? Student { get; set; }
    }
}

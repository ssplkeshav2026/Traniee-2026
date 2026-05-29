using First.netAssigmnet.Models;
using System.ComponentModel.DataAnnotations;

namespace First.netAssigmnet.ViewModel
{
    public class ExamViewModel
    {
        [Required]

        public int? ExamId { get; set; }
        [Required]

        public int? ExamTypeId { get; set; }
        [Required]

        public string? Name { get; set; }
        [Required]

        public DateOnly? StartDate { get; set; }
        public List<ExamType>? ExamTypes { get; set; } = default;

        public virtual ExamType? ExamType { get; set; }
        public object? UpcomingExams { get;  set; }
        public List<Exam>? RecentExams { get;  set; }
    }
     
}





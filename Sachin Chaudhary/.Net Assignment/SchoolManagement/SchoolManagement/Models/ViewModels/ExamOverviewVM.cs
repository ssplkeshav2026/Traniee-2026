namespace SchoolManagement.Models.ViewModels
{
    public class ExamOverviewVM
    {
        public int ExamId { get; set; }

        public int? ExamTypeId { get; set; }

        public string? name { get; set; }

        public DateOnly? StartDate { get; set; }

        public virtual ICollection<ExamResult> ExamResults { get; set; } = new List<ExamResult>();

        public virtual ExamType? ExamType { get; set; }
       
        public List<Exam> UpcomingExams { get; set; } = new();

        public List<Exam> RecentExams { get; set; } = new();
        public object ClassWisePerformance { get; internal set; }
    }
}

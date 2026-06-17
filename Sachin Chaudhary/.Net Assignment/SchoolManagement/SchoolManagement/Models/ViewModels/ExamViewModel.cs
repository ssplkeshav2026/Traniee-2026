namespace SchoolManagement.Models.ViewModels
{
    public class ExamViewModel
    {
        public int ExamId { get; set; }

        public int? ExamTypeId { get; set; }

        public string? Name { get; set; }

        public DateOnly? StartDate { get; set; }

        public virtual ICollection<ExamResults> ExamResults { get; set; } = new List<ExamResults>();

        public virtual ExamType? ExamType { get; set; }
    }
}

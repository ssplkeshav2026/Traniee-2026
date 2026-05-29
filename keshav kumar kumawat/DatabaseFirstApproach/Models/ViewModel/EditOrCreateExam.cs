namespace DatabaseFirstApproach.Models.ViewModel
{
    public class EditOrCreateExam
    {
        public int ExamId { get; set; }

        public int? ExamTypeId { get; set; }

        public string? Name { get; set; }

        public DateOnly? StartDate { get; set; }
    }
}

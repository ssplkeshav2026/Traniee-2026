using students.Models;

namespace students.ViewModels.Exams
{
    public class ExamEditViewModel
    {
        public int ExamId { get; set; }

        public int? ExamTypeId { get; set; }

        public string? Name { get; set; }

        public DateOnly? StartDate { get; set; }

        public ExamEditViewModel ToViewModel(Exam exam)
        {
            return new ExamEditViewModel()
            {
                ExamId = exam.ExamId,
                ExamTypeId = exam.ExamTypeId,
                Name = exam.Name,
                StartDate = exam.StartDate
            };
        }

        public Exam ToDataModel()
        {
            return new Exam()
            {
                ExamId = this.ExamId,
                ExamTypeId = this.ExamTypeId,
                Name = this.Name,
                StartDate = this.StartDate
            };
        }
    }
}
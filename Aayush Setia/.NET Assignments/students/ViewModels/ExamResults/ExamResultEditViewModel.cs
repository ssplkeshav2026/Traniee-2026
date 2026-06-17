using students.Models;
using ExamResultsModel = students.Models.ExamResults;

namespace students.ViewModels.ExamResults
{
    public class ExamResultEditViewModel
    {
        public int ExamId { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public string? Marks { get; set; }

        #region References

        public virtual Exam? Exam { get; set; }

        public virtual Student? Student { get; set; }

        public virtual Course? Course { get; set; }

        #endregion

        public ExamResultEditViewModel ToViewModel(ExamResultsModel result)
        {
            return new ExamResultEditViewModel()
            {
                ExamId = result.ExamId,
                StudentId = result.StudentId,
                CourseId = result.CourseId,
                Marks = result.Marks
            };
        }

        public ExamResultsModel ToDataModel()
        {
            return new ExamResultsModel()
            {
                ExamId = this.ExamId,
                StudentId = this.StudentId,
                CourseId = this.CourseId,
                Marks = this.Marks
            };
        }
    }
}
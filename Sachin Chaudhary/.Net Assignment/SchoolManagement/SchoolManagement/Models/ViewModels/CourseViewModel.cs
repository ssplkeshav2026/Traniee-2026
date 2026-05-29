namespace SchoolManagement.Models.ViewModels
{
    public class CourseViewModel
    {
        public int CourseId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int? GradeId { get; set; }

        public virtual ICollection<ExamResults> ExamResults { get; set; } = new List<ExamResults>();

        public virtual Grade? Grade { get; set; }
    }
}

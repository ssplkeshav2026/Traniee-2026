namespace DatabaseFirstApproach.Models.ViewModel
{
    public class EditOrCreateCourse
    {
        public int CourseId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int? GradeId { get; set; }
    }
}

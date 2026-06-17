using students.Models;
using System.ComponentModel.DataAnnotations;

namespace students.ViewModels.Courses
{
    public class CourseEditViewModel
    {
        public int CourseId { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }
        public int? GradeId { get; set; }

        public CourseEditViewModel ToViewModel(Course course)
        {
            return new CourseEditViewModel()
            {
                CourseId = course.CourseId,
                Name = course.Name,
                Description = course.Description
            };
        }

        public Course ToDataModel()
        {
            return new Course()
            {
                CourseId = this.CourseId,
                Name = this.Name,
                Description = this.Description,
                GradeId = this.GradeId
            };
        }
    }
}

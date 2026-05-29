using First.netAssigmnet.Models;
using System.ComponentModel.DataAnnotations;

namespace First.netAssigmnet.ViewModel
{
    public class CourseViewModel
    {
        [Required]
        public int? CourseId { get; set; }
        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public int? GradeId { get; set; }

        public List<Grade>? Grades { get; set; } = default;

        public virtual Grade? Grade { get; set; } 
    }
}

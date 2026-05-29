using First.netAssigmnet.Models;
using System.ComponentModel.DataAnnotations;

namespace First.netAssigmnet.ViewModel
{
    public class ClassroomViewModel
    {
        [Required]
        public int? ClassroomId { get; set; }

        [Required]
        public DateOnly? Year { get; set; }

        [Required]
        public int? GradeId { get; set; }

        [Required]
        public string? Section { get; set; }

        public bool? Status { get; set; }

        public string? Remarks { get; set; }

        [Required]
        public int? TeacherId { get; set; }

        public List<Grade>? Grades { get; set; } = default;

        public virtual Grade? Grade { get; set; }

        public List<Teacher>? Teachers { get; set; } = default;
        public virtual Teacher? Teacher { get; set; }
    }
}

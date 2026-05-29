using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.ViewModel
{
    public class CourseEditViewModel
    {
        public int CourseId { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Description { get; set; }

        public int? GradeId { get; set; }
    }
}

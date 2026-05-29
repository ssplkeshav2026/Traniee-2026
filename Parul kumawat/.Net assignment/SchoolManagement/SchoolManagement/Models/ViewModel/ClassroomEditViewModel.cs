using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.ViewModel
{
    public class ClassroomEditViewModel
    {
        public int ClassroomId { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateOnly? ClassroomYear { get; set; }
        [MaxLength(20)]
        [Required]
        public string? Section { get; set; }

        public bool? Status { get; set; }

        public string? Remarks { get; set; }

        public int? GradeId { get; set; }

        public int? TeacherId { get; set; }
    }
}

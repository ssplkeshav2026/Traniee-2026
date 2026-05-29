using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.ViewModel
{
    public class ExamEditViewModel
    {
        public int ExamId { get; set; }
        [Required]
        public int? ExamTypeId { get; set; }
        [Required]
        [MaxLength(20)]
        public string? Name { get; set; }
        [DataType(DataType.Date)]

        public DateOnly? StartDate { get; set; }
    }
}

using First.netAssigmnet.Models;
using System.ComponentModel.DataAnnotations;

namespace First.netAssigmnet.ViewModel
{
    public class AttendenceViewModel
    {

        [Required]
        public DateOnly? Date { get; set; }
        [Required]
        public int? StudentId { get; set; }
        [Required]
        public bool? Status { get; set; }

        public string? Remark { get; set; }

        public virtual Student? Student { get; set; }
    }
}

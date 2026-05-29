using SchoolManagementSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.ViewModels
{
    public class ClassroomViewModel
    {
        public int ClassroomId { get; set; }

        [Required]
        public int? Yearr { get; set; }

        [Required]
        public int? GradeId { get; set; }

        [Required]
        public string? Selection { get; set; }

        public bool? Status { get; set; }

        public string? Remark { get; set; }

        [Required]
        public int? TeacherId { get; set; }

        public virtual Grade? Grade { get; set; }

        public virtual Teacher? Teacher { get; set; }
    }
}
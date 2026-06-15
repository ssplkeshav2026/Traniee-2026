using System.ComponentModel.DataAnnotations;

namespace EmployeeTaskManagementSystemMVC.ViewModels
{
    public class TaskVM
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string AssignedToUserId { get; set; }

        [Required]
        public string AssignedByUserId { get; set; }

        [Required]
        public string Status { get; set; }

        public DateTime DueDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}

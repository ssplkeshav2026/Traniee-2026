using System.ComponentModel.DataAnnotations;

namespace EmployeeTaskManagementSystemMVC.ViewModels
{
    public class TaskCreateVM
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string AssignedToUserId { get; set; }

        [Required]
        public DateTime DueDate { get; set; }
    }
}

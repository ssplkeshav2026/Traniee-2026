using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystemMVC.ViewModel
{
    public class CreateTaskViewModel
    {
        [Required]
        public string Title { get; set; } 

        public string Description { get; set; } 

        public string AssignedToUserId { get; set; }

        [Required]
        public DateTime DueDate { get; set; } = DateTime.Now.AddDays(7);
    }
}

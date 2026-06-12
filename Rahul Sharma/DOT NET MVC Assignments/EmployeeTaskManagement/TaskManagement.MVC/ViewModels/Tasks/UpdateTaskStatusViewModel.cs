using System.ComponentModel.DataAnnotations;

namespace TaskManagement.MVC.ViewModels.Tasks
{
    public class UpdateTaskStatusViewModel
    {
        [Required]
        public int Status { get; set; }
    }
}
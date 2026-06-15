using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TaskManagement.MVC.ViewModels.Tasks
{
    public class CreateTaskViewModel
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string AssignedToUserId { get; set; } = string.Empty;

        [Required]
        public DateTime DueDate { get; set; }

        public List<SelectListItem> Employees { get; set; } = new();
    }
}
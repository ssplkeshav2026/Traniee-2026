using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TaskManagement.MVC.ViewModels.Tasks
{
    public class EditTaskViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string AssignedToUserId { get; set; } = string.Empty;

        [Required]
        public int Status { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public List<SelectListItem> Employees { get; set; } = new();

        public List<SelectListItem> StatusList { get; set; } = new();
    }
}
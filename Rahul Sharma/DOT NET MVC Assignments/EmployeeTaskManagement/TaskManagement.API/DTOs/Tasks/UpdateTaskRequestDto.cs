using System.ComponentModel.DataAnnotations;
using TaskManagement.API.Models.Enums;

namespace TaskManagement.API.DTOs.Tasks
{
    public class UpdateTaskRequestDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string AssignedToUserId { get; set; } = string.Empty;

        [Required]
        public TaskStatusType Status { get; set; }

        [Required]
        public DateTime DueDate { get; set; }
    }
}
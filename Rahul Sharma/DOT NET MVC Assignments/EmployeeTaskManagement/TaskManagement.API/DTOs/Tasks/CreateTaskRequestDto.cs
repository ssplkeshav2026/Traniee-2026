using System.ComponentModel.DataAnnotations;

namespace TaskManagement.API.DTOs.Tasks
{
    public class CreateTaskRequestDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string AssignedToUserId { get; set; } = string.Empty;

        [Required]
        public DateTime DueDate { get; set; }
    }
}
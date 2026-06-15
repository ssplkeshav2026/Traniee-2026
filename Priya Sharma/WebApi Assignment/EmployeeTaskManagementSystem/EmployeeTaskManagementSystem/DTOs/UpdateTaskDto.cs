using System.ComponentModel.DataAnnotations;
using TaskManagementSystemApi.Models;

namespace TaskManagementSystemApi.DTOs
{
    public class UpdateTaskDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string? AssignedToUserId { get; set; }

        [Required]
        public TaskitemStatus Status { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

    }
}

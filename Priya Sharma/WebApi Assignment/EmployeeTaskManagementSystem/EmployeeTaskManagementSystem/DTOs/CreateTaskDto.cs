using System.ComponentModel.DataAnnotations;
using TaskManagementSystemApi.Models;

namespace TaskManagementSystemApi.DTOs
{
    public class CreateTaskDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string AssignedToUserId { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public TaskitemStatus Status { get; set; }
    }
}

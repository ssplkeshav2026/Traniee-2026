using System.ComponentModel.DataAnnotations;
using TaskManagement.API.Models.Enums;

namespace TaskManagement.API.DTOs.Tasks
{
    public class UpdateTaskStatusDto
    {
        [Required]
        public TaskStatusType Status { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace EmployeeTaskManagementSystemAPI.Dto
{
    public class TaskCreateDto
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string AssignedToUserId { get; set; }

        [Required]
        public DateTime DueDate { get; set; }
    }
}

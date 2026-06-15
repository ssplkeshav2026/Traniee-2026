using System.ComponentModel.DataAnnotations;

namespace EmployeeTaskManagementSystemAPI.Dto
{
    public class TaskUpdateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public string AssignedToUserId { get; set; }

        [Required]
        public string Status { get; set; }

        public DateTime DueDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}

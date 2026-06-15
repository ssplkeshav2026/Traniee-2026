using TaskManagement.API.Models.Enums;

namespace TaskManagement.API.Models
{
    public class EmployeeTask
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string AssignedToUserId { get; set; } = string.Empty;

        public ApplicationUser? AssignedToUser { get; set; }

        public string AssignedByUserId { get; set; } = string.Empty;

        public ApplicationUser? AssignedByUser { get; set; }

        public TaskStatusType Status { get; set; } = TaskStatusType.Pending;

        public DateTime DueDate { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedDate { get; set; }
    }
}
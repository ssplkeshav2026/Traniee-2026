namespace EmployeeTaskManagementSystemAPI.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public string AssignedToUserId { get; set; }
        public string AssignedByUserId { get; set; }

        public string Status { get; set; } = "Pending";

        public DateTime DueDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
}

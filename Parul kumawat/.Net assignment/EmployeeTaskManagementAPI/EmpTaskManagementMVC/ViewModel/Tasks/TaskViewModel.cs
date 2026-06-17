namespace EmpTaskManagementMVC.ViewModel.Tasks
{
    public class TaskViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string AssignedToUserId { get; set; } = string.Empty;

        public string AssignedByUserId { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public DateTime DueDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}

namespace TaskManagement.MVC.ViewModels.Tasks
{
    public class TaskResponseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string AssignedToUserId { get; set; } = string.Empty;
        public string AssignedToUserName { get; set; } = string.Empty;

        public string AssignedByUserId { get; set; } = string.Empty;
        public string AssignedByUserName { get; set; } = string.Empty;

        public int Status { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
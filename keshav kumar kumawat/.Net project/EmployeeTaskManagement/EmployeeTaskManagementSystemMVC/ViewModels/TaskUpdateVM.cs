namespace EmployeeTaskManagementSystemMVC.ViewModels
{
    public class TaskUpdateVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string AssignedToUserId { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
    }
}

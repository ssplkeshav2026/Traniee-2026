namespace TaskManagementSystemMVC.ViewModel
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string AssignedToUserId { get; set; }
        public string AssignedToName { get; set; }
        public string AssignedByName { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

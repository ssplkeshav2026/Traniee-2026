namespace TaskManagement.MVC.ViewModels.Dashboard
{
    public class RecentTaskViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string AssignedToUserName { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public DateTime DueDate { get; set; }
    }
}
using System.Collections.Generic;

namespace TaskManagement.MVC.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalTasks { get; set; }
        public int CompletedTasks { get; set; }
        public int PendingTasks { get; set; }
        public int MyTasksCount { get; set; }
        public List<TaskViewModel> RecentTasks { get; set; } = new List<TaskViewModel>();
    }
}  
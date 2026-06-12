using TaskManagement.MVC.ViewModels.Auth;

namespace TaskManagement.MVC.ViewModels.Dashboard
{
    public class DashboardViewModel
    {
        public UserSessionViewModel User { get; set; } = new();

        public int TotalTasks { get; set; }

        public int PendingTasks { get; set; }

        public int InProgressTasks { get; set; }

        public int CompletedTasks { get; set; }

        public List<RecentTaskViewModel> RecentTasks { get; set; } = new();

        public int TotalUsers { get; set; }

        public int TotalManagers { get; set; }

        public int TotalEmployees { get; set; }

        public double TaskCompletionRate { get; set; }

        public int TasksCompletedToday { get; set; }

        public int TasksPendingToday { get; set; }


    }
}
namespace TaskManagement.API.DTOs.Dashboard
{
    public class DashboardStatsDto
    {
        public int TotalTasks { get; set; }
        public int PendingTasks { get; set; }
        public int InProgressTasks { get; set; }
        public int CompletedTasks { get; set; }

        public List<RecentTaskDto> RecentTasks { get; set; } = new();


        public int TotalUsers { get; set; }

        public int TotalManagers { get; set; }

        public int TotalEmployees { get; set; }

        public double TaskCompletionRate { get; set; }

        public int TasksCompletedToday { get; set; }

        public int TasksPendingToday { get; set; }
    }
}
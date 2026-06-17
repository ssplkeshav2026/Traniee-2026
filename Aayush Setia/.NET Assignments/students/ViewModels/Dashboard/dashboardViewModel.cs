namespace students.ViewModels.Dashboard
    {
        public class DashboardViewModel
        {
            public StudentStatisticsViewModel StudentStatistics { get; set; }

            public AttendanceOverviewViewModel AttendanceOverview { get; set; }

            public ExamOverviewViewModel ExamOverview { get; set; }

            public QuickMetricsViewModel QuickMetrics { get; set; }
        }
   }

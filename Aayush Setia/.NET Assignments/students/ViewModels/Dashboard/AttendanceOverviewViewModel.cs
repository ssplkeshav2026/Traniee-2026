namespace students.ViewModels.Dashboard
{
    public class AttendanceOverviewViewModel
    {
        public int PresentStudents { get; set; }

        public int AbsentStudents { get; set; }

        public double AttendancePercentage { get; set; }

        public List<string> RecentAttendances { get; set; }
    }
}
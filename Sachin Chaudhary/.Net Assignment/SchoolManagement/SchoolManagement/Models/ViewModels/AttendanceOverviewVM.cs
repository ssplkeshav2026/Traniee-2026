namespace SchoolManagement.Models.ViewModels
{
    public class AttendanceOverviewVM
    {
        public int PresentToday { get; set; }

        public int PresentThisWeek { get; set; }

        public int AbsentToday { get; set; }

        public int AbsentThisWeek { get; set; }

        public Dictionary<string, double>? AttendancePercentageByClassroom { get; set; }

        public List<Attendance>? RecentAttendanceRecords { get; set; }

        public double? AttendencePercentage { get; set; }
        public int?ClassroomId { get; set; }
       
    }
}
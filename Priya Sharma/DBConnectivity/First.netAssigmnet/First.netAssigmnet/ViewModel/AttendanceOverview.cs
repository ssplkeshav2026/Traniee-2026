using First.netAssigmnet.Models;

namespace First.netAssigmnet.ViewModel
{
    public class Attendance_Overview
    {
        public int PresentToday { get; set; }

        public int PresentThisWeek { get; set; }

        public int AbsentToday { get; set; }

        public int AbsentThisWeek { get; set; }
        public DateOnly AttendenceDate { get; set; }


        public Dictionary<string, double>? AttendencePercentageByClassroom { get; set; }
        public double? AttendencePercentage { get; set; }


        public List<Attendance>? RecentAttendanceRecords { get; set; }
        public List<Attendance>? RecentAttendance { get;  set; }
    }
}

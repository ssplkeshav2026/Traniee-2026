using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalStudents { get; set; }
        public int ActiveStudents { get; set; }
        public int InactiveStudents { get; set; }

        public int TotalTeachers { get; set; }
        public int TotalParents { get; set; }
        public int TotalCourses { get; set; }
        public int TotalGrades { get; set; }

        public int TodayPresent { get; set; }
        public int TodayAbsent { get; set; }

        public List<Exam> UpcomingExams { get; set; } = new();
        public List<Exam> RecentExams { get; set; } = new();
        public List<Attendance> RecentAttendance { get; set; } = new();
    }
}
using DatabaseFirstApproach.Models;

namespace DatabaseFirstApproach.Models.ViewModel
{
    public class DashboardVM
    {
        public int TotalStudents { get; set; }
        public List<GradeStudentModel> GradeStudent { get; set; }
        public int ActiveStudents { get; set; }
        public int InactiveStudents { get; set; }



        public int PresentStudents { get; set; }
        public int AbsentStudents { get; set; }
        public double AttendencePercentage { get; set; }
        public List<AttendenceClassroomModel> AttendenceClassroom { get; set; }
        public List<Attendance> AttendenceRecords { get; set; } = new List<Attendance>();




        public List<Exam> UpcomingExams { get; set; }
        public List<Exam> RecentExams { get; set; }
        public List<ClassPerformanceModel> Performance { get; set; } = new List<ClassPerformanceModel>();



        public int TotalTeachers { get; set; }
        public int TotalParents { get; set; }
        public int TotalCourses { get; set; }
        public int TotalGrades { get; set; }
    }
}

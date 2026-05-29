namespace SchoolManagement.Models.ViewModel
{
    public class DashboardViewModel
    {
        public int TotalStudents { get; set; }

        public List<GradeStudentCountViewModel> GradeStudentCount { get; set; }
        public int ActiveStudents { get; set; }
        public int InactiveStudents { get; set; }

        public int PresentStudents { get; set; }
        public int AbsentStudents { get; set; }
        public double AttendencePercent { get; set; }

        public List<AttendanceClassroomViewModel> ClassroomAttendance { get; set; }

        public List<Attendence> AttendenceRecords { get; set; }
        public List<Exam> UpcomingExams { get; set; }
         
        public List<Exam> RecentExam { get; set; }
        public List<ClassPerformanceViewModel> Performance {  get; set; }

        public int TotalTeachers { get; set; }
        public int TotalParents { get; set; }
        public int TotalCourses { get; set; }
        public int TotalGrades { get; set; }


    }
}

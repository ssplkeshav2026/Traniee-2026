namespace SchoolManagement.Models.ViewModels
{
    public class StudentStatisticsVM
    {

      
            public int TotalStudents { get; set; }


            public int ActiveStudents { get; set; }


            public int InactiveStudents { get; set; }


            public Dictionary<string, int>? StudentsPerClassroom { get; set; }
        public bool? Status { get; set; }

        public int? ClassroomId { get; set; }
        //public Dictionary<string, double> AttendancePercentageByClassroom { get; set; } = new();
        public Dictionary<string, int> AttendancePercentageByClassroom { get; set; } = new();


    }
}

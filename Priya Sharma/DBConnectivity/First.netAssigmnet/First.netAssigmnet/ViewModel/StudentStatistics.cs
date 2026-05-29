namespace First.netAssigmnet.ViewModel
{
    public class Student_Statistics
    {
        public int TotalStudents { get; set; }

        public int ActiveStudents { get; set; }

        public int InactiveStudents { get; set; }

        public Dictionary<string, int> StudentsPerClassroom { get; set; }
           = new Dictionary<string, int>();

    }
}

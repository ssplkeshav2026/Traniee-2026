using students.Models;
using System.ComponentModel.DataAnnotations;

//namespace students.Models
//{
//    public class exam_result
//    {

//        [Key]


//        public int ExamId { get; set; }

//        public int StudentId { get; set; }

//        public int CourseId { get; set; }

//        public decimal Marks { get; set; }

//        public virtual Exam Exam { get; set; }

//        public virtual Student Student { get; set; }

//        public virtual Course Course { get; set; }
//    }
//}



//public class ExamResults
//{
//    public int ExamId { get; set; }

//    public int StudentId { get; set; }

//    public int CourseId { get; set; }

//    public string Marks { get; set; }


//    public virtual Exam Exam { get; set; }

//    public virtual Student Student { get; set; }

//    public virtual Course Course { get; set; }
//}



namespace students.Models
{
    public class ExamResults
    {
        public int ExamId { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public string Marks { get; set; }

        public virtual Exam Exam { get; set; }

        public virtual Student Student { get; set; }

        public virtual Course Course { get; set; }
    }
}
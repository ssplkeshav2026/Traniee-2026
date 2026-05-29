
using First.netAssigmnet.Models;

namespace First.netAssigmnet.ViewModel
{
    public class Exam_Overview
    {
        public DateOnly? StartDate { get; set; }

        public List<Exam>? UpcomingExams { get; set; }

        public List<Exam>? RecentExams { get; set; }

    }

   
}

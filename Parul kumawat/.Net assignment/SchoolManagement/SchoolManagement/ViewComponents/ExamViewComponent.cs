using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models;
using SchoolManagement.Models.ViewModel;

namespace SchoolManagement.ViewComponents
{
    public class ExamViewComponent : ViewComponent
    {
        private readonly SchoolErpContext _context;

        public ExamViewComponent(SchoolErpContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            DashboardViewModel dashboard = new DashboardViewModel();

            dashboard.UpcomingExams = _context.Exams.OrderByDescending(p => p.StartDate).ToList();
            dashboard.RecentExam = _context.Exams.Where(p => p.StartDate <= DateOnly.FromDateTime(DateTime.Today)).OrderBy(p => p.StartDate).ToList();



            //dashboard.Performance = _context.ClassroomStudents.GroupBy(x => x.ClassroomId)
            //    .Select(y => new ClassPerformanceViewModel
            //    {
            //        GradeName = "Class " + y.Key,
            //        AverageMarks = _context.ExamResults.Where(a => y.Any(s => s.StudentId == a.StudentId)).Average(a => a.Marks)
            //    }).ToList();

            //var da = _context.ClassroomStudents.ToList();

            var data = _context.ClassroomStudents.GroupBy(x => x.ClassroomId);

            var data1 = data.Select(y => new ClassPerformanceViewModel
            {
                ClassroomId = y.Key,
                AverageMarks = _context.ExamResults.Where(a => y.Any(s => s.StudentId == a.StudentId)).Average(a => a.Marks)
            }).ToList();
            dashboard.Performance = data1;


            //List<ClassPerformanceViewModel> list = new();
            //foreach (var x in da.ToList())
            //{
            //    ClassPerformanceViewModel model = new();
            //    model.GradeName = "Class " + x.ClassroomId;
            //    var marks =
            //    model.AverageMarks = _context.ExamResults.Where(a => a.StudentId == x.StudentId).Select(x => x.Marks).FirstOrDefault();
            //    list.Add(model);
            //}
            //dashboard.Performance = list;
            //return View(dashboard);
            return View(dashboard);
        }
    }
}

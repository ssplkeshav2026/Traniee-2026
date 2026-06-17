using Microsoft.AspNetCore.Mvc;
using students.Models;
using System.Diagnostics;
using students.ViewModels.Dashboard;


namespace students.Controllers
{
    public class HomeController : Controller
    {
        private readonly SchoolDbContext _context;

        public HomeController(SchoolDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            var model = new DashboardViewModel()
            {
                StudentStatistics = new StudentStatisticsViewModel()
                {
                    TotalStudents = _context.Students.Count(),
                    ActiveStudents = _context.Students.Count(s => s.Status == true),
                    InactiveStudents = _context.Students.Count(s => s.Status == false)
                },

                AttendanceOverview = new AttendanceOverviewViewModel()
                {
                    PresentStudents = 120,
                    AbsentStudents = 15,
                    AttendancePercentage = 88.5,
                    RecentAttendances = new List<string>()
                    {
                        "Rahul Present",
                        "Aman Absent",
                        "Priya Present"
                    }
                },

                ExamOverview = new ExamOverviewViewModel()
                {
                    UpcomingExams = _context.Exams.Count(),
                    CompletedExams = 5,
                    AverageMarks = 76.4
                },

                QuickMetrics = new QuickMetricsViewModel()
                {
                    TotalTeachers = _context.Teachers.Count(),
                    TotalParents = _context.Parents.Count(),
                    TotalCourses = _context.Courses.Count(),
                    TotalClassrooms = _context.Classrooms.Count()
                }
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
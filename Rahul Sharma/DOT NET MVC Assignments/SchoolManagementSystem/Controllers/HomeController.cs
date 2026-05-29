using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModels;
namespace SchoolManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly SchoolDbContext _context;

        public HomeController(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Dashboard()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);

            var vm = new DashboardViewModel
            {
                TotalStudents = await _context.Students.CountAsync(),

                ActiveStudents = await _context.Students
                .CountAsync(x => x.Status == true),

                InactiveStudents = await _context.Students
                .CountAsync(x => x.Status == false),

                TotalTeachers = await _context.Teachers.CountAsync(),
                TotalParents = await _context.Parents.CountAsync(),
                TotalCourses = await _context.Cources.CountAsync(),
                TotalGrades = await _context.Grades.CountAsync(),

                TodayPresent = await _context.Attendances
                 .CountAsync(x => x.Status == true),

                TodayAbsent = await _context.Attendances
                .CountAsync(x => x.Status == false),

                UpcomingExams = await _context.Exams
                    .OrderBy(x => x.StartDate)
                    .Take(5)
                    .ToListAsync(),

                RecentExams = await _context.Exams
                    .OrderByDescending(x => x.StartDate)
                    .Take(5)
                    .ToListAsync(),

                RecentAttendance = await _context.Attendances
              .OrderByDescending(x => x.Datee)
              .Take(5)
              .ToListAsync(),
            };

            return View(vm);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

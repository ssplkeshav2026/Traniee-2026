using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models;
using SchoolManagement.Models.ViewModels;

namespace SchoolManagement.ViewComponents
{
    [ViewComponent(Name = "QuickMetrics")]

    public class QuickMetricsViewComponent : ViewComponent
    {
        private readonly SchooErpContext _context;

        public QuickMetricsViewComponent(SchooErpContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var vm = new QuickMetricsVM
            {
                TotalTeachers = _context.Teachers.Count(),
                TotalParents = _context.Parents.Count(),
                TotalCourses = _context.Courses.Count(),
                TotalSections = _context.Classrooms.Count()
            };

            return View(vm);
        }
    }
}
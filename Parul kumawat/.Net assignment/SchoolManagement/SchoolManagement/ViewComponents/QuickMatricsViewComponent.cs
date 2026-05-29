using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models;
using SchoolManagement.Models.ViewModel;

namespace SchoolManagement.ViewComponents
{
    public class QuickMatricsViewComponent : ViewComponent
    {
        private readonly SchoolErpContext _context;

        public QuickMatricsViewComponent(SchoolErpContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            DashboardViewModel dashboard = new DashboardViewModel();
            dashboard.TotalTeachers = _context.Teachers.Count();
            dashboard.TotalParents = _context.Parents.Count();
            dashboard.TotalCourses = _context.Courses.Count();
            dashboard.TotalGrades = _context.Grades.Count();
            return View(dashboard);
        }



        
    }
}

using DatabaseFirstApproach.Models;
using DatabaseFirstApproach.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirstApproach.ViewComponents
{
    [ViewComponent(Name = "QuickMetrics")]
    public class QuickMetricsViewComponent:ViewComponent
    {
        private readonly SchooErpContext _context;

        public QuickMetricsViewComponent(SchooErpContext context)
        {
            _context = context;
        }

        DateTime today = DateTime.Today;

        DashboardVM vm = new DashboardVM();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            vm.TotalTeachers = await _context.Teachers.CountAsync();
            vm.TotalParents = await _context.Parents.CountAsync();
            vm.TotalCourses = await _context.Courses.CountAsync();
            vm.TotalGrades = await _context.Grades.CountAsync();

            return View(vm);
        }
    }
}

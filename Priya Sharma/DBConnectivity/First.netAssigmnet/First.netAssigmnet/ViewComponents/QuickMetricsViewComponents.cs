using First.netAssigmnet.Models;
using First.netAssigmnet.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace First.netAssigmnet.ViewComponents
{
    [ViewComponent(Name = "QuickMetrics")]

    public class QuickMetricsViewComponent : ViewComponent
    {
        private readonly SchooErpContext _context;

        public QuickMetricsViewComponent(SchooErpContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Quick_Metrics vm = new Quick_Metrics();

            vm.TotalTeachers =
                await _context.Teachers.CountAsync();

            vm.TotalParents =
                await _context.Parents.CountAsync();

            vm.TotalCourses =
                await _context.Courses.CountAsync();

            vm.TotalGrades =
                await _context.Grades.CountAsync();

            return View(vm);
        }
    }
}
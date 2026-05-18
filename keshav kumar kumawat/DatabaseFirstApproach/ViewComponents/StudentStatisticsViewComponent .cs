using DatabaseFirstApproach.Models;
using DatabaseFirstApproach.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirstApproach.ViewComponents
{
    [ViewComponent(Name = "StudentStatistics")]
    public class StudentStatisticsViewComponent : ViewComponent
    {
        private readonly SchooErpContext _context;

        public StudentStatisticsViewComponent(SchooErpContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            DateTime today = DateTime.Today;

            DashboardVM vm = new DashboardVM();

            // Student Statistics
            vm.TotalStudents = await _context.Students.CountAsync();

            vm.ActiveStudents = await _context.Students.CountAsync(x => x.Status == true);

            vm.InactiveStudents = await _context.Students.CountAsync(x => x.Status == false);

            vm.GradeStudent = await _context.Classrooms
    .Select(c => new GradeStudentModel
    {
        GradeName = c.GradeId + " - " + c.Section,
        TotalStudentCount = _context.ClassroomStudents.Count(cs => cs.ClassroomId == c.ClassroomId)
    }).ToListAsync();

            return View(vm);

        }
    }
}


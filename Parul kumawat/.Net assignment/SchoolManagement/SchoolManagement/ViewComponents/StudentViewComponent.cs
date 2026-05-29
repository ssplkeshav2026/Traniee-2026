using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models;
using SchoolManagement.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.ViewComponents
{
    public class StudentViewComponent : ViewComponent
    {
        private readonly SchoolErpContext _context;

        public StudentViewComponent(SchoolErpContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            DashboardViewModel dashboard = new DashboardViewModel();
            dashboard.TotalStudents = _context.Students.Count();
            dashboard.ActiveStudents =  _context.Students.Count(x => x.Status == true);
            dashboard.InactiveStudents = _context.Students.Count(x => x.Status == false);

            var groupedData = _context.ClassroomStudents.GroupBy(x => x.ClassroomId);

            dashboard.GradeStudentCount = groupedData.Select(x => new GradeStudentCountViewModel
            {
                ClassroomId = x.Key,
                TotalStudentCount = x.Count(),
            }).ToList();
            return View(dashboard);
        }
    }
}

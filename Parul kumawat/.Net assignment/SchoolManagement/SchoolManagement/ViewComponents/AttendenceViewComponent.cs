using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;
using SchoolManagement.Models.ViewModel;

namespace SchoolManagement.ViewComponents
{
    public class AttendenceViewComponent : ViewComponent
    {
        private readonly SchoolErpContext _context;

        public AttendenceViewComponent(SchoolErpContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            DashboardViewModel dashboard = new DashboardViewModel();



            dashboard.AttendenceRecords = _context.Attendences.OrderByDescending(x => x.Date).Take(10).ToList();

            dashboard.PresentStudents = _context.Attendences.Count(x => x.Status == true && x.Date == DateOnly.FromDateTime(DateTime.Today));
            dashboard.AbsentStudents = _context.Attendences.Count(x => x.Status == false && x.Date == DateOnly.FromDateTime(DateTime.Today));


          
          

            var groupData = _context.ClassroomStudents.GroupBy(x => x.ClassroomId);
            dashboard.ClassroomAttendance = groupData.Select(y => new AttendanceClassroomViewModel
            {
                ClassroomId = y.Key,
                Percentage = (
                _context.Attendences.Count
                (x => x.Status == true && x.Date == DateOnly.FromDateTime(DateTime.Today)
                && y.Any(z => z.StudentId == x.StudentId)) * 100.0 / y.Count()),
            }).ToList();


            return View(dashboard);
        }
    }
}

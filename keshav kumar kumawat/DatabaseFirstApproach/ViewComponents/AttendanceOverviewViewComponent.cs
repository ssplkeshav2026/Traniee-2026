using DatabaseFirstApproach.Models;
using DatabaseFirstApproach.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirstApproach.ViewComponents
{
    [ViewComponent(Name = "AttendanceOverview")]
    public class AttendanceOverviewViewComponent : ViewComponent
    {

        private readonly SchooErpContext _context;

        public AttendanceOverviewViewComponent(SchooErpContext context)
        {
            _context = context;
        }

        DateTime today = DateTime.Today;

        DashboardVM vm = new DashboardVM();

        public async Task<IViewComponentResult> InvokeAsync()
        {

            DateTime today = DateTime.Today;

            DashboardVM vm = new DashboardVM();

            vm.PresentStudents = await _context.Attendances.CountAsync(x => x.Date == DateOnly.FromDateTime(today) && x.Status == true);

            vm.AbsentStudents = await _context.Attendances.CountAsync(x => x.Date == DateOnly.FromDateTime(today) && x.Status == false);

            int totalAttendanceToday = vm.PresentStudents + vm.AbsentStudents;

            vm.AttendencePercentage = totalAttendanceToday == 0 ? 0 : Math.Round((vm.PresentStudents * 100.0) / totalAttendanceToday, 2); //(Present Students / Total Students) × 100

            // Attendance Percentage By Classroom
            vm.AttendenceClassroom = await _context.Classrooms
                 .Select(c => new AttendenceClassroomModel
                 {
                     ClassroomId = c.ClassroomId,    // current classroom ki id store karo. 

                     Percentage = _context.Attendances.Where(a => a.Student.StudentId == c.ClassroomId).Count() == 0 ? 0
                         : Math.Round(_context.Attendances.Where(a => a.Student.StudentId == c.ClassroomId && a.Status == true).Count() * 100.0
                             /
                             _context.Attendances.Where(a => a.Student.StudentId == c.ClassroomId).Count(), 2)
                 }).ToListAsync();

            // Recent Attendance Records
            vm.AttendenceRecords = await _context.Attendances
                .Include(a => a.Student)
                .OrderByDescending(a => a.Date)
                .Take(5)
                .ToListAsync();

            return View(vm);

        }
    }
}

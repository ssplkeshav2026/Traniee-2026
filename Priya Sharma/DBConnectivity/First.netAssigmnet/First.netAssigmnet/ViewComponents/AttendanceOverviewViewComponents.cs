using First.netAssigmnet.Models;
using Microsoft.AspNetCore.Mvc;
using First.netAssigmnet.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace First.netAssigmnet.ViewComponents
{
    [ViewComponent(Name = "AttendanceOverview")]
    public class AttendanceOverviewViewComponents : ViewComponent
    {
        private readonly SchooErpContext _context;

        public AttendanceOverviewViewComponents(SchooErpContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Attendance_Overview vm = new Attendance_Overview();

            var today = DateOnly.FromDateTime(DateTime.Today);

            vm.PresentToday = await _context.Attendances .CountAsync(a =>
                    a.Date == today && a.Status == true);

            vm.AbsentToday = await _context.Attendances .CountAsync(a =>
                    a.Date == today  && a.Status == false);

            int total = vm.PresentToday + vm.AbsentToday;

            vm.AttendencePercentage = total > 0
                ? (double)vm.PresentToday * 100 / total
                : 0;

            vm.RecentAttendance =
                await _context.Attendances
                .OrderByDescending(a => a.Date)
                .Take(5)
                .ToListAsync();

            return View(vm);
        }

    }
}

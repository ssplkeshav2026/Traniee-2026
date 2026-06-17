using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;
using SchoolManagement.Models.ViewModels;

namespace SchoolManagement.ViewComponents
{
    [ViewComponent(Name = "AttendanceOverviewGet")]
    public class AttendanceOverviewViewComponent : ViewComponent
    {
        private readonly SchooErpContext _context;

        public AttendanceOverviewViewComponent(SchooErpContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);

            var vm = new AttendanceOverviewVM
            {
                PresentToday = await _context.Attendances
                    .CountAsync(a => a.Date == today && a.Status == true),

                AbsentToday = await _context.Attendances
                    .CountAsync(a => a.Date == today && a.Status == false),

                RecentAttendanceRecords = await _context.Attendances
                    .OrderByDescending(a => a.Date)
                    .Take(5)
                    .ToListAsync()
            };

            return View(vm);
        }
    }
}
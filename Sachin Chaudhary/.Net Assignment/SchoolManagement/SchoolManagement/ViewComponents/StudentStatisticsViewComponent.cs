using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models;
using SchoolManagement.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.ViewComponents
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
            var vm = new StudentStatisticsVM()
            {
                TotalStudents = await _context.Students.CountAsync(),

                ActiveStudents = await _context.Students
                    .CountAsync(s => s.Status == true),

                InactiveStudents = await _context.Students
                    .CountAsync(s => s.Status == false)
            };
            vm.StudentsPerClassroom = await (
                from c in _context.Classrooms
                join g in _context.Grades
                    on c.GradeId equals g.GradeId
                group c by g.Name into grouped
                select new
                {
                    GradeName = grouped.Key,
                    Count = grouped.Count()
                }
            ).ToDictionaryAsync(
                x => x.GradeName ?? "Unknown",
                x => x.Count
            );

            //StudentsPerClassroom = _context.Classrooms
            //        .ToDictionary(
            //           c => c.Classroomname,
            //c => _context.Students.Count(s => s.ClassroomId == c.ClassroomId)
            //        )


            //            vm.StudentsPerClassroom = new Dictionary<string, int>
            //      {
            //      { "Class A", 20 },
            //    { "Class B", 15 },
            //    { "Class C", 30 }
            //};
            return View(vm);
        }
    }
}
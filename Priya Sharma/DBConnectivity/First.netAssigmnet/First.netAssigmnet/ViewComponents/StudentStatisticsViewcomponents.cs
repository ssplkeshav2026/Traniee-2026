using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using First.netAssigmnet.ViewComponents;
using First.netAssigmnet.ViewModel;
using First.netAssigmnet.Models;


namespace First.netAssigmnet.ViewComponents
{
    [ViewComponent(Name = "StudentStatistics")]
    public class StudentStatisticsViewcomponents : ViewComponent
    {
        
        private readonly SchooErpContext _context;

        public StudentStatisticsViewcomponents(SchooErpContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Student_Statistics vm = new Student_Statistics();

            // Total Students
            vm.TotalStudents = await _context.Students.CountAsync();

            // Active Students
            vm.ActiveStudents =   await _context.Students
                .CountAsync(s => s.Status == true);

            // Inactive Students
            vm.InactiveStudents = await _context.Students
                .CountAsync(s => s.Status == false);

            // Students per Grade
            vm.StudentsPerClassroom = await (
                from cs in _context.ClassroomStudent
                join c in _context.Classrooms
                    on cs.ClassroomId equals c.ClassroomId
                join g in _context.Grades
                    on c.GradeId equals g.GradeId
                group cs by g.Name into grouped
                select new
                {
                    GradeName = grouped.Key,
                    Count = grouped.Count()
                }
            ).ToDictionaryAsync(
                x => x.GradeName ?? "Unknown",
                x => x.Count
            );

            return View(vm);
        }

    }
}

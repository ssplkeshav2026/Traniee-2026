using DatabaseFirstApproach.Models;
using DatabaseFirstApproach.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirstApproach.ViewComponents
{
    [ViewComponent(Name = "ExamOverview")]
    public class ExamOverviewViewComponent : ViewComponent
    {
                                                                                                                                                                                                                                        
        private readonly SchooErpContext _context;

        public ExamOverviewViewComponent(SchooErpContext context)
        {
            _context = context;
        }
        DateTime today = DateTime.Today;

        DashboardVM vm = new DashboardVM();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            vm.UpcomingExams = await _context.Exams
           .Where(x => x.StartDate >= DateOnly.FromDateTime(today))                          // DateTime ko sirf date me convert karo.
           .OrderBy(x => x.StartDate)      // To show nearest exam
           .ToListAsync();

            vm.RecentExams = await _context.Exams
            .Where(x => x.StartDate < DateOnly.FromDateTime(today))                           // sirf past exams lao  
            .OrderByDescending(x => x.StartDate).Take(10).ToListAsync();

            // Class-wise Exam Performance
            vm.Performance = await _context.ExamResults
                .Include(x => x.Student)
                .Where(x => x.Student != null && x.Marks != null)                     // Student exist karta ho.  // Marks empty/null nahi hone chahiye.
                .GroupBy(x => x.Student.ParentId)                                      // data ko ParentId ke according group karo.
                .Select(g => new ClassPerformanceModel
                {
                    GradeName = g.Key.ToString(),                                       // group ka naam store karo.

                    AverageMarks = Math.Round(g.Average(x => (double)x.Marks.Value), 2)
                }).ToListAsync();
            return View(vm);
        }
    }
}
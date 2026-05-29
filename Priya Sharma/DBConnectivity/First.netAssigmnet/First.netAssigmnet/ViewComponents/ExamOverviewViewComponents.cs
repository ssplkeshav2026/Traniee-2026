using First.netAssigmnet.Models;
using First.netAssigmnet.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices.Java;

namespace First.netAssigmnet.ViewComponents

{
    [ViewComponent(Name = "ExamOverview")]

    public class ExamOverviewViewComponents : ViewComponent
    {

        private readonly SchooErpContext _context;

        public ExamOverviewViewComponents(SchooErpContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Exam_Overview vm = new Exam_Overview();

            var today = DateOnly.FromDateTime(DateTime.Today);


            vm.UpcomingExams = await _context.Exams
             .Where(e => e.StartDate >= today)
             .OrderBy(e => e.StartDate)
             .Take(5)
             .ToListAsync();

            vm.RecentExams = await _context.Exams
                .Where(e => e.StartDate < today)
                .OrderByDescending(e => e.StartDate)
                .Take(5)
                .ToListAsync();


            
            return View(vm);
        }
    }

}






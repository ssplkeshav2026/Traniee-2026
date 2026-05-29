using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;
using SchoolManagement.Models.ViewModels;

namespace SchoolManagement.ViewComponents
{
    [ViewComponent(Name = "ExamOverviewGet")]
    public class ExamOverviewViewComponent : ViewComponent
    {
        private readonly SchooErpContext _context;

        public ExamOverviewViewComponent(SchooErpContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);

            var vm = new ExamOverviewVM
            {
                UpcomingExams = _context.Exams
                    .Where(e => e.StartDate >= today)
                    .OrderBy(e => e.StartDate)
                    .Take(5)
                    .ToList(),

                RecentExams = _context.Exams
                    .Where(e => e.StartDate < today)
                    .OrderByDescending(e => e.StartDate)
                    .Take(5)
                    .ToList(),

          
           

        };


            return View(vm);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using First.netAssigmnet.Models;

namespace First.netAssigmnet.Controllers
{
    public class ExamResultsController : Controller
    {
        private readonly SchooErpContext context;

        public ExamResultsController(SchooErpContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var schooErpContext = context.ExamResults.Include(e => e.Course).Include(e => e.Exam).Include(e => e.Student);
            return View(await schooErpContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? ExamId, int? StudentId, int? CourseId)
        {
            if (ExamId == null || StudentId == null || CourseId == null)
            {
                return NotFound();
            }

            var examResult = await context.ExamResults
                .Include(e => e.Course)
                .Include(e => e.Exam)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m =>
                    m.ExamId == ExamId &&
                    m.StudentId == StudentId &&
                    m.CourseId == CourseId);

            if (examResult == null)
            {
                return NotFound();
            }

            return View(examResult);
        }

        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(context.Courses, "CourseId", "Name");
            ViewData["ExamId"] = new SelectList(context.Exams, "ExamId", "ExamId");
            ViewData["StudentId"] = new SelectList(context.Students, "StudentId", "StudentId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExamResult examResult)
        {
            if (ModelState.IsValid)
            {
                context.Add(examResult);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(context.Courses, "CourseId", "Name", examResult.CourseId);
            ViewData["ExamId"] = new SelectList(context.Exams, "ExamId", "ExamId", examResult.ExamId);
            ViewData["StudentId"] = new SelectList(context.Students, "StudentId", "StudentId", examResult.StudentId);
            return View(examResult);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? ExamId, int? StudentId, int? CourseId)
        {
            if (ExamId == null || StudentId == null || CourseId == null)
            {
                return NotFound();
            }

            var examResult = await context.ExamResults
                .FindAsync(StudentId, CourseId, ExamId);

            if (examResult == null)
            {
                return NotFound();
            }

            ViewData["CourseId"] = new SelectList(
                context.Courses,
                "CourseId",
                "CourseId",
                examResult.CourseId);

            ViewData["ExamId"] = new SelectList(
                context.Exams,
                "ExamId",
                "ExamId",
                examResult.ExamId);

            ViewData["StudentId"] = new SelectList(
                context.Students,
                "StudentId",
                "StudentId",
                examResult.StudentId);

            return View(examResult);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int ExamId,int StudentId,int CourseId, ExamResult examResult)
        {
            if (ExamId != examResult.ExamId ||
                StudentId != examResult.StudentId ||
                CourseId != examResult.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
                {
                try
                {
                    context.Update(examResult);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamResultExists(
                        examResult.ExamId,
                        examResult.StudentId,
                        examResult.CourseId))
                    {
                        return NotFound();
                    }
                
                       throw;
                    }

                    return RedirectToAction(nameof(Index));
                }

                return View(examResult);
            }

            private bool ExamResultExists(int? ExamId, int? StudentId, int? CourseId)
            {
              return context.ExamResults.Any(e =>
                  e.ExamId == ExamId &&
                  e.StudentId == StudentId &&
                  e.CourseId == CourseId);
             }


        [HttpGet]
    public async Task<IActionResult> Delete(int? ExamId, int? StudentId, int? CourseId)
        {
            if (ExamId == null || StudentId == null || CourseId == null)
            {
                return NotFound();
            }

            var examResult = await context.ExamResults
                .Include(e => e.Course)
                .Include(e => e.Exam)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m =>
                    m.ExamId == ExamId &&
                    m.StudentId == StudentId &&
                    m.CourseId == CourseId);

            if (examResult == null)
            {
                return NotFound();
            }

            return View(examResult);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRows (int ExamId, int StudentId, int CourseId)
        {
            var examResult = await context.ExamResults
                .FindAsync(StudentId, CourseId, ExamId);

            if (examResult != null)
            {
                context.ExamResults.Remove(examResult);
                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ExamResultExists(int id)
        {
            return context.ExamResults.Any(e => e.StudentId == id);
        }
    }
}






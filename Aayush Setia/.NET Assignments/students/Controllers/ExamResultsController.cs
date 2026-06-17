using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using students.Models;
using students.ViewModels.ExamResults;

namespace students.Controllers
{
    public class ExamResultsController : Controller
    {
        private readonly SchoolDbContext _context;

        public ExamResultsController(SchoolDbContext context)
        {
            _context = context;
        }

        // INDEX
        public async Task<IActionResult> Index()
        {
            var schoolDbContext = _context.ExamResults
                .Include(e => e.Course)
                .Include(e => e.Exam)
                .Include(e => e.Student);

            return View(await schoolDbContext.ToListAsync());
        }

        // DETAILS
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examResult = await _context.ExamResults
                .Include(e => e.Course)
                .Include(e => e.Exam)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.StudentId == id);

            if (examResult == null)
            {
                return NotFound();
            }

            return View(examResult);
        }

        // CREATE GET
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId");

            ViewData["ExamId"] = new SelectList(_context.Exams, "ExamId", "ExamId");

            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FName");

            var viewModel = new ExamResultEditViewModel();

            return View("Edit", viewModel);
        }

        // CREATE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExamResultEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var examResult = viewModel.ToDataModel();

                _context.Add(examResult);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId");

            ViewData["ExamId"] = new SelectList(_context.Exams, "ExamId", "ExamId");

            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FName");

            return View("Edit", viewModel);
        }

        // EDIT GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examResult = await _context.ExamResults.FindAsync(id);

            if (examResult == null)
            {
                return NotFound();
            }

            var viewModel = new ExamResultEditViewModel().ToViewModel(examResult);

            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", examResult.CourseId);

            ViewData["ExamId"] = new SelectList(_context.Exams, "ExamId", "ExamId", examResult.ExamId);

            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FName", examResult.StudentId);

            return View(viewModel);
        }

        // EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ExamResultEditViewModel viewModel)
        {
            if (id != viewModel.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var examResult = viewModel.ToDataModel();

                    _context.Update(examResult);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamResultExists(viewModel.StudentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", viewModel.CourseId);

            ViewData["ExamId"] = new SelectList(_context.Exams, "ExamId", "ExamId", viewModel.ExamId);

            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FName", viewModel.StudentId);

            return View(viewModel);
        }

        // DELETE GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examResult = await _context.ExamResults
                .Include(e => e.Course)
                .Include(e => e.Exam)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.StudentId == id);

            if (examResult == null)
            {
                return NotFound();
            }

            return View(examResult);
        }

        // DELETE POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var examResult = await _context.ExamResults.FindAsync(id);

            if (examResult != null)
            {
                _context.ExamResults.Remove(examResult);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ExamResultExists(int id)
        {
            return _context.ExamResults.Any(e => e.StudentId == id);
        }
    }
}
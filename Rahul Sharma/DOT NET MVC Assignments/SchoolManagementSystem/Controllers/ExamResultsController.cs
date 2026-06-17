using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModels;

namespace SchoolManagementSystem.Controllers
{
    public class ExamResultsController : Controller
    {
        private readonly SchoolDbContext _context;

        public ExamResultsController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: ExamResults
        public async Task<IActionResult> Index()
        {
            var schoolDbContext = _context.ExamResults.Include(e => e.Cource).Include(e => e.Exam).Include(e => e.Student);
            return View(await schoolDbContext.ToListAsync());
        }

        // GET: ExamResults/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examResult = await _context.ExamResults
                .Include(e => e.Cource)
                .Include(e => e.Exam)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (examResult == null)
            {
                return NotFound();
            }

            return View(examResult);
        }

        


        // GET: ExamResults/Create
        public IActionResult Create()
        {
            ViewData["CourceId"] = new SelectList(_context.Cources, "CourceId", "CourceId");
            ViewData["ExamId"] = new SelectList(_context.Exams, "ExamId", "ExamId");
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");

            return View("CreateEdit", new ExamResultViewModel());
        }


        // GET: ExamResults/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examResult = await _context.ExamResults
                .FirstOrDefaultAsync(e => e.StudentId == id);

            if (examResult == null)
            {
                return NotFound();
            }

            var vm = new ExamResultViewModel
            {
                ExamId = examResult.ExamId,
                StudentId = examResult.StudentId,
                CourceId = examResult.CourceId,
                Marks = examResult.Marks
            };

            ViewData["CourceId"] = new SelectList(_context.Cources, "CourceId", "CourceId", vm.CourceId);
            ViewData["ExamId"] = new SelectList(_context.Exams, "ExamId", "ExamId", vm.ExamId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", vm.StudentId);

            return View("CreateEdit", vm);
        }


        // POST: ExamResults/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(ExamResultViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewData["CourceId"] = new SelectList(_context.Cources, "CourceId", "CourceId", vm.CourceId);
                ViewData["ExamId"] = new SelectList(_context.Exams, "ExamId", "ExamId", vm.ExamId);
                ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", vm.StudentId);

                return View("CreateEdit", vm);
            }

            var existingResult = await _context.ExamResults
                .FirstOrDefaultAsync(e =>
                    e.ExamId == vm.ExamId &&
                    e.StudentId == vm.StudentId &&
                    e.CourceId == vm.CourceId);

            if (existingResult == null)
            {
                var examResult = new ExamResult
                {
                    ExamId = vm.ExamId,
                    StudentId = vm.StudentId,
                    CourceId = vm.CourceId,
                    Marks = vm.Marks
                };

                _context.ExamResults.Add(examResult);
            }
            else
            {
                existingResult.Marks = vm.Marks;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: ExamResults/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examResult = await _context.ExamResults
                .Include(e => e.Cource)
                .Include(e => e.Exam)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (examResult == null)
            {
                return NotFound();
            }

            return View(examResult);
        }

        // POST: ExamResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var examResult = await _context.ExamResults.FindAsync(id);
            if (examResult != null)
            {
                _context.ExamResults.Remove(examResult);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamResultExists(int? id)
        {
            return _context.ExamResults.Any(e => e.StudentId == id);
        }
    }
}

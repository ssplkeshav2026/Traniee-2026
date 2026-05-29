using DatabaseFirstApproach.Models;
using DatabaseFirstApproach.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirstApproach.Controllers
{
    public class ExamResultsController : Controller
    {
        private readonly SchooErpContext _context;

        public ExamResultsController(SchooErpContext context)
        {
            _context = context;
        }

        // GET: ExamResults
        public async Task<IActionResult> Index()
        {
            var schooErpContext = _context.ExamResults.Include(e => e.Course).Include(e => e.Exam).Include(e => e.Student);
            return View(await schooErpContext.ToListAsync());
        }

        // GET: ExamResults/Details/5
        public async Task<IActionResult> Details(int? examId, int? studentId, int? courseId)
        {
            if (examId == null || studentId == null || courseId == null)
            {
                return NotFound();
            }

            var examResult = await _context.ExamResults
                .Include(e => e.Course)
                .Include(e => e.Exam)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m =>
                    m.ExamId == examId &&
                    m.StudentId == studentId &&
                    m.CourseId == courseId);

            if (examResult == null)
            {
                return NotFound();
            }

            return View(examResult);
        }

        // GET: ExamResults/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId");
            ViewData["ExamId"] = new SelectList(_context.Exams, "ExamId", "ExamId");
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            return View();
        }

        // POST: ExamResults/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExamId,StudentId,CourseId,Marks")] ExamResult examResult)
        {
            if (ModelState.IsValid)
            {
                _context.Add(examResult);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", examResult.CourseId);
            ViewData["ExamId"] = new SelectList(_context.Exams, "ExamId", "ExamId", examResult.ExamId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", examResult.StudentId);
            return View(examResult);
        }

        // GET: ExamResults/Edit/5
        public async Task<IActionResult> Edit(int? examId, int? studentId, int? courseId)
        {
            if (examId == null || studentId == null || courseId == null)
            {
                return NotFound();
            }

            var examResults = await _context.ExamResults
                .FirstOrDefaultAsync(x =>
                    x.ExamId == examId &&
                    x.StudentId == studentId &&
                    x.CourseId == courseId);

            if (examResults == null)
            {
                return NotFound();
            }

            return View(examResults);
        }

        // ====================== CONTROLLER ======================
           [HttpPost]
           [ValidateAntiForgeryToken]
           public async Task<IActionResult> Edit(
        int examId,
        int studentId,
        int courseId,
        [Bind("ExamId,StudentId,CourseId,Marks")] ExamResult examResults)
           {
               var oldData = await _context.ExamResults
                   .FirstOrDefaultAsync(x =>
                       x.ExamId == examId &&
                       x.StudentId == studentId &&
                       x.CourseId == courseId);

               if (oldData == null)
               {
                   return NotFound();
               }

               oldData.Marks = examResults.Marks;

               await _context.SaveChangesAsync();

               return RedirectToAction(nameof(Index));
           }
        private bool ExamResultsExists(int? examId, int? studentId, int? courseId)
        {
            throw new NotImplementedException();
        }

        private bool ExamResultsExists(int examId, int studentId, int courseId)
        {
            return _context.ExamResults.Any(e =>
                e.ExamId == examId &&
                e.StudentId == studentId &&
                e.CourseId == courseId);
        }

        // GET: ExamResults/Delete/5
        public async Task<IActionResult> Delete(int? examId, int? studentId, int? courseId)
        {
            if (examId == null || studentId == null || courseId == null)
            {
                return NotFound();
            }

            var examResults = await _context.ExamResults
                .Include(e => e.Course)
                .Include(e => e.Exam)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(x =>
                    x.ExamId == examId &&
                    x.StudentId == studentId &&
                    x.CourseId == courseId);

            if (examResults == null)
            {
                return NotFound();
            }

            return View(examResults);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(
    int examId,
    int studentId,
    int courseId)
        {
            var examResults = await _context.ExamResults
                .FirstOrDefaultAsync(x =>
                    x.ExamId == examId &&
                    x.StudentId == studentId &&
                    x.CourseId == courseId);

            if (examResults == null)
            {
                return NotFound();
            }

            _context.ExamResults.Remove(examResults);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ExamResultExists(int? id)
        {
            return _context.ExamResults.Any(e => e.StudentId == id);
        }
    }
}

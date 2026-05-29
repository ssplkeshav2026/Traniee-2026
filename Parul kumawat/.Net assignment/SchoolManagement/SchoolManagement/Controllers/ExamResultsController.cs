using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    public class ExamResultsController : Controller
    {
        private readonly SchoolErpContext _context;

        public ExamResultsController(SchoolErpContext context)
        {
            _context = context;
        }

        // GET: ExamResults
        public async Task<IActionResult> Index()
        {
            var schoolErpContext = _context.ExamResults.Include(e => e.Course).Include(e => e.Exam).Include(e => e.Student);
            return View(await schoolErpContext.ToListAsync());
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
                .FirstOrDefaultAsync(m => m.ExamId == examId && m.StudentId == studentId && m.CourseId == courseId);
            if (examResult == null)
            {
                return NotFound();
            }

            return View(examResult);
        }

        // GET: ExamResults/Create
        public IActionResult Create()
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
                _context.ExamResults.Add(examResult);
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

            var examResult = await _context.ExamResults.FindAsync(examId,studentId,courseId);
            if (examResult == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", examResult.CourseId);
            ViewData["ExamId"] = new SelectList(_context.Exams, "ExamId", "ExamId", examResult.ExamId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", examResult.StudentId);
            return View(examResult);
        }

        // POST: ExamResults/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int examId, int studentId, int courseId , [Bind("ExamId,StudentId,CourseId,Marks")] ExamResult examResult)
        {
            if (examId != examResult.ExamId || studentId != examResult.StudentId || courseId != examResult.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(examResult);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamResultExists(examResult.ExamId,examResult.StudentId,examResult.CourseId))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", examResult.CourseId);
            ViewData["ExamId"] = new SelectList(_context.Exams, "ExamId", "ExamId", examResult.ExamId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", examResult.StudentId);
            return View(examResult);
        }

        // GET: ExamResults/Delete/5
        public async Task<IActionResult> Delete(int? examId, int? studentId, int? courseId)
        {
            if (examId == null || studentId == null || courseId == null)
            {
                return NotFound();
            }

            var examResult = await _context.ExamResults
                .Include(e => e.Course)
                .Include(e => e.Exam)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.ExamId == examId && m.StudentId == studentId && m.CourseId == courseId);
            if (examResult == null)
            {
                return NotFound();
            }

            return View(examResult);
        }

        // POST: ExamResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int examId, int studentId, int courseId)
        {
            var examResult = await _context.ExamResults.FindAsync(examId, studentId, courseId);
            if (examResult != null)
            {
                _context.ExamResults.Remove(examResult);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamResultExists(int? examId, int? studentId, int? courseId)
        { 
        throw new NotImplementedException();
        }
    
        private bool ExamResultExists(int examId, int studentId, int courseId)
        {
            return _context.ExamResults.Any(e => e.ExamId == examId && e.StudentId == studentId && e.CourseId == courseId);
        }
    }
}

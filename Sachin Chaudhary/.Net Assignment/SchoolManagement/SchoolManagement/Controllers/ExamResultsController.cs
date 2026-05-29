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
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examResults = await _context.ExamResults
                .Include(e => e.Course)
                .Include(e => e.Exam)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.ResultId == id);
            if (examResults == null)
            {
                return NotFound();
            }

            return View(examResults);
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
        public async Task<IActionResult> Create([Bind("ExamId,StudentId,CourseId,Marks,ResultId")] ExamResults examResults)
        {
            if (ModelState.IsValid)
            {
                _context.Add(examResults);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", examResults.CourseId);
            ViewData["ExamId"] = new SelectList(_context.Exams, "ExamId", "ExamId", examResults.ExamId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", examResults.StudentId);
            return View(examResults);
        }

        // GET: ExamResults/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examResults = await _context.ExamResults.FindAsync(id);
            if (examResults == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", examResults.CourseId);
            ViewData["ExamId"] = new SelectList(_context.Exams, "ExamId", "ExamId", examResults.ExamId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", examResults.StudentId);
            return View(examResults);
        }

        // POST: ExamResults/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExamId,StudentId,CourseId,Marks,ResultId")] ExamResult examResults)
        {
            if (id != examResults.ResultId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(examResults);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamResultsExists(examResults.ResultId))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", examResults.CourseId);
            ViewData["ExamId"] = new SelectList(_context.Exams, "ExamId", "ExamId", examResults.ExamId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", examResults.StudentId);
            _ = _context.SaveChangesAsync();
            return View(examResults);
        }

        // GET: ExamResults/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examResults = await _context.ExamResults
                .Include(e => e.Course)
                .Include(e => e.Exam)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.ResultId == id);
            if (examResults == null)
            {
                return NotFound();
            }

            return View(examResults);
        }

        // POST: ExamResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var examResults = await _context.ExamResults.FindAsync(id);
            if (examResults != null)
            {
                _context.ExamResults.Remove(examResults);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamResultsExists(int id)
        {
            return _context.ExamResults.Any(e => e.ResultId == id);
        }
    }
}

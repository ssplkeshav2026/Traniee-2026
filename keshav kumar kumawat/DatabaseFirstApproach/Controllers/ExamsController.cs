using DatabaseFirstApproach.Models;
using DatabaseFirstApproach.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseFirstApproach.Controllers
{
    public class ExamsController : Controller
    {
        private readonly SchooErpContext _context;

        public ExamsController(SchooErpContext context)
        {
            _context = context;
        }

        // GET: Exams
        public async Task<IActionResult> Index()
        {
            var schooErpContext = _context.Exams.Include(e => e.ExamType);
            return View(await schooErpContext.ToListAsync());
        }

        // GET: Exams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.Exams
                .Include(e => e.ExamType)
                .FirstOrDefaultAsync(m => m.ExamId == id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // GET: Exams/Create
        public async Task<IActionResult> CreateAsync(int? id)
        {
            ViewData["ExamTypeId"] = new SelectList(_context.ExamTypes, "ExamTypeId", "ExamTypeId");

            if (id == null || id == 0)
            {
                return View(new EditOrCreateExam());
            }
            var studentData = await _context.Exams.FirstOrDefaultAsync(x => x.ExamId == id);
            if (studentData == null)
            {
                return NotFound();
            }
            EditOrCreateExam e = new EditOrCreateExam()
            {
                ExamId = studentData.ExamId,
                ExamTypeId = studentData.ExamTypeId,
                Name = studentData.Name,
                StartDate = studentData.StartDate
            };
            return View(e);
        }

        [HttpPost]
        public async Task<IActionResult> EditExam(EditOrCreateExam e)
        {
            if (ModelState.IsValid)
            {
                var exist = await _context.Exams.FirstOrDefaultAsync(x => x.ExamId == e.ExamId);

                if (exist != null)
                {
                    exist.ExamId = e.ExamId;
                    exist.ExamTypeId = e.ExamTypeId;
                    exist.Name = e.Name;
                    exist.StartDate = e.StartDate;

                    TempData["Message"] = "Exams Update successfully";
                }
                else
                {
                    int newExamId = 1;

                    if (await _context.Students.AnyAsync())
                    {
                        newExamId = await _context.Exams.MaxAsync(x => x.ExamId) + 1;
                    }

                    Exam s = new Exam()
                    {
                        ExamId = newExamId,
                        ExamTypeId = e.ExamTypeId,
                        Name = e.Name,
                        StartDate = e.StartDate
                    };

                    await _context.Exams.AddAsync(s);
                    TempData["Message"] = "Exam Add successfully";
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ExamTypeId = new SelectList(_context.Exams, "ExamTypeId", "ExamTypeId", e.ExamTypeId);
            return View("Create", e);
        }

        private bool ClassroomExists(int id)
        {
            return _context.Classrooms.Any(e => e.ClassroomId == id);
        }

        // POST: Exams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ExamId,ExamTypeId,Name,StartDate")] Exam exam)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(exam);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ExamTypeId"] = new SelectList(_context.ExamTypes, "ExamTypeId", "ExamTypeId", exam.ExamTypeId);
        //    return View(exam);
        //}

        // GET: Exams/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var exam = await _context.Exams.FindAsync(id);
        //    if (exam == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["ExamTypeId"] = new SelectList(_context.ExamTypes, "ExamTypeId", "ExamTypeId", exam.ExamTypeId);
        //    return View(exam);
        //}

        // POST: Exams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ExamId,ExamTypeId,Name,StartDate")] Exam exam)
        //{
        //    if (id != exam.ExamId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(exam);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ExamExists(exam.ExamId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ExamTypeId"] = new SelectList(_context.ExamTypes, "ExamTypeId", "ExamTypeId", exam.ExamTypeId);
        //    return View(exam);
        //}

        // GET: Exams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.Exams
                .Include(e => e.ExamType)
                .FirstOrDefaultAsync(m => m.ExamId == id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam != null)
            {
                _context.Exams.Remove(exam);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamExists(int id)
        {
            return _context.Exams.Any(e => e.ExamId == id);
        }
    }
}

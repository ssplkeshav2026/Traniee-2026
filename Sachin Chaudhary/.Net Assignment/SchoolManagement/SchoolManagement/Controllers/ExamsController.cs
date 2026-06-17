using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;
using SchoolManagement.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Controllers
{
    public class ExamsController : Controller
    {
        private readonly SchooErpContext _context;

        public ExamsController(SchooErpContext context)
        {
            _context = context;
        }

        // INDEX
        public async Task<IActionResult> Index()
        {
            var schooErpContext = _context.Exams
                .Include(e => e.ExamType);

            return View(await schooErpContext.ToListAsync());
        }

        // DETAILS
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

        // CREATE + EDIT GET
        public async Task<IActionResult> Create(int? id)
        {
            ViewData["ExamTypeId"] = new SelectList(
                _context.ExamTypes,
                "ExamTypeId",
                "ExamTypeId"
            );

            // CREATE
            if (id == null || id == 0)
            {
                return View(new ExamViewModel());
            }

            // EDIT
            var examData = await _context.Exams
                .FirstOrDefaultAsync(x => x.ExamId == id);

            if (examData == null)
            {
                return NotFound();
            }

            ExamViewModel vm = new ExamViewModel()
            {
                ExamId = examData.ExamId,
                ExamTypeId = examData.ExamTypeId,
                Name = examData.Name,
                StartDate = examData.StartDate
            };

            return View(vm);
        }
        // CREATE + EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditExam(ExamViewModel e)
        {
            if (ModelState.IsValid)
            {
                var exist = await _context.Exams
                    .FirstOrDefaultAsync(x => x.ExamId == e.ExamId);

                // UPDATE
                if (exist != null)
                {
                    exist.ExamTypeId = e.ExamTypeId;
                    exist.Name = e.Name;
                    exist.StartDate = e.StartDate;

                    TempData["Message"] = "Exam Updated Successfully";
                }

                // CREATE
                else
                {
                    int newExamId = 1;

                    if (await _context.Exams.AnyAsync())
                    {
                        newExamId = await _context.Exams.MaxAsync(x => x.ExamId) + 1;
                    }

                    Exam exam = new Exam()
                    {
                        ExamId = newExamId,
                        ExamTypeId = e.ExamTypeId,
                        Name = e.Name,
                        StartDate = e.StartDate
                    };

                    await _context.Exams.AddAsync(exam);

                    TempData["Message"] = "Exam Added Successfully";
                }

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["ExamTypeId"] = new SelectList(
                _context.ExamTypes,
                "ExamTypeId",
                "ExamTypeId",
                e.ExamTypeId
            );

            return View("Create", e);
        }

        // DELETE GET
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

        // DELETE POST
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
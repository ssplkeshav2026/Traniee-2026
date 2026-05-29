using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Controllers
{
    public class ExamsController : Controller
    {
        private readonly SchoolDbContext _context;

        public ExamsController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: Exams
        public async Task<IActionResult> Index()
        {
            var schoolDbContext = _context.Exams.Include(e => e.ExamType);
            return View(await schoolDbContext.ToListAsync());
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
        public IActionResult Create()
        {
            ViewData["ExamTypeId"] = new SelectList(_context.ExamTypes, "ExamTypeId", "ExamTypeId");

            return View("CreateEdit", new ExamViewModel());
        }


        // GET: Exams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.Exams.FindAsync(id);

            if (exam == null)
            {
                return NotFound();
            }

            var vm = new ExamViewModel
            {
                ExamId = exam.ExamId,
                ExamTypeId = exam.ExamTypeId,
                Name = exam.Name,
                StartDate = exam.StartDate
            };

            ViewData["ExamTypeId"] = new SelectList(_context.ExamTypes, "ExamTypeId", "ExamTypeId", vm.ExamTypeId);

            return View("CreateEdit", vm);
        }


        // POST: Exams/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(ExamViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewData["ExamTypeId"] = new SelectList(_context.ExamTypes, "ExamTypeId", "ExamTypeId", vm.ExamTypeId);

                return View("CreateEdit", vm);
            }

            if (vm.ExamId == 0)
            {
                int newId = _context.Exams.Any()
                    ? _context.Exams.Max(e => e.ExamId) + 1
                    : 1;

                var exam = new Exam
                {
                    ExamId = newId,
                    ExamTypeId = vm.ExamTypeId,
                    Name = vm.Name,
                    StartDate = vm.StartDate
                };

                _context.Exams.Add(exam);
            }
            else
            {
                var exam = await _context.Exams.FindAsync(vm.ExamId);

                if (exam == null)
                {
                    return NotFound();
                }

                exam.ExamTypeId = vm.ExamTypeId;
                exam.Name = vm.Name;
                exam.StartDate = vm.StartDate;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

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

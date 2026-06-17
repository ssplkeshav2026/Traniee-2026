using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using students.Models;
using students.ViewModels.Classrooms;

namespace students.Controllers
{
    public class ClassroomsController : Controller
    {
        private readonly SchoolDbContext _context;

        public ClassroomsController(SchoolDbContext context)
        {
            _context = context;
        }

        // INDEX
        public async Task<IActionResult> Index()
        {
            var classrooms = _context.Classrooms.Include(c => c.Teacher);

            return View(await classrooms.ToListAsync());
        }

        // DETAILS
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classroom = await _context.Classrooms
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.ClassroomId == id);

            if (classroom == null)
            {
                return NotFound();
            }

            return View(classroom);
        }

        // CREATE GET
        public IActionResult Create()
        {
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId");

            var viewModel = new ClassroomEditViewModel();

            return View("Edit", viewModel);
        }

        // CREATE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClassroomEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var classroom = viewModel.ToDataModel();

                _context.Add(classroom);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", viewModel.TeacherId);

            return View("Edit", viewModel);
        }

        // EDIT GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classroom = await _context.Classrooms.FindAsync(id);

            if (classroom == null)
            {
                return NotFound();
            }

            var viewModel = new ClassroomEditViewModel().ToViewModel(classroom);

            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", classroom.TeacherId);

            return View(viewModel);
        }

        // EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClassroomEditViewModel viewModel)
        {
            if (id != viewModel.ClassroomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var classroom = viewModel.ToDataModel();

                    _context.Update(classroom);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassroomExists(viewModel.ClassroomId))
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

            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", viewModel.TeacherId);

            return View(viewModel);
        }

        // DELETE GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classroom = await _context.Classrooms
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.ClassroomId == id);

            if (classroom == null)
            {
                return NotFound();
            }

            return View(classroom);
        }

        // DELETE POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classroom = await _context.Classrooms.FindAsync(id);

            if (classroom != null)
            {
                _context.Classrooms.Remove(classroom);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ClassroomExists(int id)
        {
            return _context.Classrooms.Any(e => e.ClassroomId == id);
        }
    }
}
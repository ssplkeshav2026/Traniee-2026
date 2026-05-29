using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModels;

namespace SchoolManagementSystem.Controllers
{
    public class CourcesController : Controller
    {
        private readonly SchoolDbContext _context;

        public CourcesController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: Cources
        public async Task<IActionResult> Index()
        {
            var schoolDbContext = _context.Cources.Include(c => c.Grade);
            return View(await schoolDbContext.ToListAsync());
        }

        // GET: Cources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cource = await _context.Cources
                .Include(c => c.Grade)
                .FirstOrDefaultAsync(m => m.CourceId == id);
            if (cource == null)
            {
                return NotFound();
            }

            return View(cource);
        }

       

        // GET: Cources/Create
        public IActionResult Create()
        {
            ViewData["GradeId"] = new SelectList(_context.Grades, "GradeId", "GradeId");

            return View("CreateEdit", new CourcesViewModel());
        }


        // GET: Cources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cource = await _context.Cources.FindAsync(id);

            if (cource == null)
            {
                return NotFound();
            }

            var vm = new CourcesViewModel
            {
                CourceId = cource.CourceId,
                Name = cource.Name,
                Description = cource.Description,
                GradeId = cource.GradeId
            };

            ViewData["GradeId"] = new SelectList(_context.Grades, "GradeId", "GradeId", vm.GradeId);

            return View("CreateEdit", vm);
        }


        // POST: Cources/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(CourcesViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewData["GradeId"] = new SelectList(_context.Grades, "GradeId", "GradeId", vm.GradeId);
                return View("CreateEdit", vm);
            }

            if (vm.CourceId == 0)
            {
                int newId = _context.Cources.Any()
                    ? _context.Cources.Max(c => c.CourceId) + 1
                    : 1;

                var cource = new Cource
                {
                    CourceId = newId,
                    Name = vm.Name,
                    Description = vm.Description,
                    GradeId = vm.GradeId
                };

                _context.Cources.Add(cource);
            }
            else
            {
                var cource = await _context.Cources.FindAsync(vm.CourceId);

                if (cource == null)
                {
                    return NotFound();
                }

                cource.Name = vm.Name;
                cource.Description = vm.Description;
                cource.GradeId = vm.GradeId;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        // GET: Cources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cource = await _context.Cources
                .Include(c => c.Grade)
                .FirstOrDefaultAsync(m => m.CourceId == id);
            if (cource == null)
            {
                return NotFound();
            }

            return View(cource);
        }

        // POST: Cources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cource = await _context.Cources.FindAsync(id);
            if (cource != null)
            {
                _context.Cources.Remove(cource);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourceExists(int id)
        {
            return _context.Cources.Any(e => e.CourceId == id);
        }
    }
}

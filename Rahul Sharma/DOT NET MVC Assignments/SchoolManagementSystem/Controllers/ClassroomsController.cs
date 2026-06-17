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
    public class ClassroomsController : Controller
    {
        private readonly SchoolDbContext _context;

        public ClassroomsController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: Classrooms
        public async Task<IActionResult> Index()
        {
            var schoolDbContext = _context.Classrooms.Include(c => c.Grade).Include(c => c.Teacher);
            return View(await schoolDbContext.ToListAsync());
        }

        // GET: Classrooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classroom = await _context.Classrooms
                .Include(c => c.Grade)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.ClassroomId == id);
            if (classroom == null)
            {
                return NotFound();
            }

            return View(classroom);
        }


        //create
        public IActionResult Create()
        {
            ViewData["GradeId"] = new SelectList(_context.Grades, "GradeId", "GradeId");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId");

            return View("CreateEdit", new ClassroomViewModel());
        }


        //edit


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

            var vm = new ClassroomViewModel
            {
                ClassroomId = classroom.ClassroomId,
                Yearr = classroom.Yearr,
                GradeId = classroom.GradeId,
                Selection = classroom.Selection,
                Status = classroom.Status,
                Remark = classroom.Remark,
                TeacherId = classroom.TeacherId
            };

            ViewData["GradeId"] = new SelectList(_context.Grades, "GradeId", "GradeId", vm.GradeId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", vm.TeacherId);

            return View("CreateEdit", vm);
        }


        //new Save method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(ClassroomViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewData["GradeId"] = new SelectList(_context.Grades, "GradeId", "GradeId", vm.GradeId);
                ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", vm.TeacherId);

                return View("CreateEdit", vm);
            }

            if (vm.ClassroomId == 0)
            {
                int newId = _context.Classrooms.Any()
                    ? _context.Classrooms.Max(c => c.ClassroomId) + 1
                    : 1;

                var classroom = new Classroom
                {
                    ClassroomId = newId,
                    Yearr = vm.Yearr,
                    GradeId = vm.GradeId,
                    Selection = vm.Selection,
                    Status = vm.Status,
                    Remark = vm.Remark,
                    TeacherId = vm.TeacherId
                };

                _context.Classrooms.Add(classroom);
            }
            else
            {
                var classroom = await _context.Classrooms.FindAsync(vm.ClassroomId);

                if (classroom == null)
                {
                    return NotFound();
                }

                classroom.Yearr = vm.Yearr;
                classroom.GradeId = vm.GradeId;
                classroom.Selection = vm.Selection;
                classroom.Status = vm.Status;
                classroom.Remark = vm.Remark;
                classroom.TeacherId = vm.TeacherId;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        // GET: Classrooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classroom = await _context.Classrooms
                .Include(c => c.Grade)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.ClassroomId == id);
            if (classroom == null)
            {
                return NotFound();
            }

            return View(classroom);
        }

        // POST: Classrooms/Delete/5
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

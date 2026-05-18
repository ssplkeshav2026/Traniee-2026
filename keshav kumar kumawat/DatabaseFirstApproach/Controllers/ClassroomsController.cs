using DatabaseFirstApproach.Models;
using DatabaseFirstApproach.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace DatabaseFirstApproach.Controllers
{
    public class ClassroomsController : Controller
    {
        private readonly SchooErpContext _context;

        public ClassroomsController(SchooErpContext context)
        {
            _context = context;
        }

        // GET: Classrooms
        public async Task<IActionResult> Index()
        {
            var schooErpContext = _context.Classrooms.Include(c => c.Grade).Include(c => c.Teacher);
            return View(await schooErpContext.ToListAsync());
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

        // GET: Classrooms/Create
        public async Task<IActionResult> Create(int? id)
        {
            ViewData["GradeId"] = new SelectList(_context.Grades, "GradeId", "GradeId");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId");
            //return View();

            if (id == null || id == 0)
            {
                return View(new EditOrCreateClassroom());
            }
            var studentData = await _context.Classrooms.FirstOrDefaultAsync(x => x.ClassroomId == id);
            if (studentData == null)
            {
                return NotFound();
            }
            EditOrCreateClassroom e = new EditOrCreateClassroom()
            {
                ClassroomId = studentData.ClassroomId,
                Year = studentData.Year,
                GradeId = studentData.GradeId,
                Section = studentData.Section,
                Status = studentData.Status,
                Remarks = studentData.Remarks,
                TeacherId = studentData.TeacherId
            };
            return View(e);

        }





        // POST: Classrooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ClassroomId,Year,GradeId,Section,Status,Remarks,TeacherId")] Classroom classroom)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(classroom);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["GradeId"] = new SelectList(_context.Grades, "GradeId", "GradeId", classroom.GradeId);
        //    ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", classroom.TeacherId);
        //    return View(classroom);
        //}

        // GET: Classrooms/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var classroom = await _context.Classrooms.FindAsync(id);
        //    if (classroom == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["GradeId"] = new SelectList(_context.Grades, "GradeId", "GradeId", classroom.GradeId);
        //    ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", classroom.TeacherId);
        //    return View(classroom);
        //}

        // POST: Classrooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ClassroomId,Year,GradeId,Section,Status,Remarks,TeacherId")] Classroom classroom)
        //{
        //    if (id != classroom.ClassroomId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(classroom);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ClassroomExists(classroom.ClassroomId))
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
        //    ViewData["GradeId"] = new SelectList(_context.Grades, "GradeId", "GradeId", classroom.GradeId);
        //    ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", classroom.TeacherId);
        //    return View(classroom);
        //}

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

        [HttpPost]
        public async Task<IActionResult> EditClassroom(EditOrCreateClassroom e)
        {
            if (ModelState.IsValid)
            {
                var exist = await _context.Classrooms.FirstOrDefaultAsync(x => x.ClassroomId == e.ClassroomId);

                if (exist != null)
                {
                    exist.ClassroomId = e.ClassroomId;
                    exist.Year = e.Year;
                    exist.GradeId = e.GradeId;
                    exist.Section = e.Section;
                    exist.Status = e.Status;
                    exist.Remarks = e.Remarks;
                    exist.TeacherId = e.TeacherId;

                    TempData["Message"] = "Classrooms Update successfully";
                }
                else
                {
                    int newClassroomId = 1;

                    if (await _context.Students.AnyAsync())
                    {
                        newClassroomId = await _context.Classrooms.MaxAsync(x => x.ClassroomId) + 1;
                    }

                    Classroom s = new Classroom()
                    {
                        ClassroomId = newClassroomId,
                        Year = e.Year,
                        GradeId = e.GradeId,
                        Section = e.Section,
                        Status = e.Status,
                        Remarks = e.Remarks,
                        TeacherId = e.TeacherId
                    };

                    await _context.Classrooms.AddAsync(s);
                    TempData["Message"] = "Classroom Add successfully";
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.GradeId = new SelectList(_context.Classrooms, "GradeId", "GradeId", e.GradeId);
            ViewBag.TeacherId = new SelectList(_context.Classrooms, "TeacherId", "TeacherId", e.TeacherId);
            return View("Create", e);
        }

        private bool ClassroomExists(int id)
        {
            return _context.Classrooms.Any(e => e.ClassroomId == id);
        }
    }
}

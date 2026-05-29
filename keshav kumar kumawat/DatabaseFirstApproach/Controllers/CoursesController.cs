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
    public class CoursesController : Controller
    {
        private readonly SchooErpContext _context;

        public CoursesController(SchooErpContext context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var schooErpContext = _context.Courses.Include(c => c.Grade);
            return View(await schooErpContext.ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Grade)
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public async Task<IActionResult> Create(int? id)
        {
            ViewData["GradeId"] = new SelectList(_context.Grades, "GradeId", "GradeId");

            if (id == null || id == 0)
            {
                return View(new EditOrCreateCourse());
            }
            var studentData = await _context.Courses.FirstOrDefaultAsync(x => x.CourseId == id);
            if (studentData == null)
            {
                return NotFound();
            }
            EditOrCreateCourse e = new EditOrCreateCourse()
            {
                CourseId = studentData.CourseId,
                Name = studentData.Name,
                Description = studentData.Description,
                GradeId = studentData.GradeId
            };
            return View(e);

        }

        [HttpPost]
        public async Task<IActionResult> EditCourse(EditOrCreateCourse e)
        {
            if (ModelState.IsValid)
            {
                var exist = await _context.Courses.FirstOrDefaultAsync(x => x.CourseId == e.CourseId);

                if (exist != null)
                {
                    exist.CourseId = e.CourseId;
                    exist.Name = e.Name;
                    exist.GradeId = e.GradeId;
                    exist.Description = e.Description;

                    TempData["Message"] = "Courses Update successfully";
                }
                else
                {
                    int newCourseId = 1;

                    if (await _context.Courses.AnyAsync())
                    {
                        newCourseId = await _context.Courses.MaxAsync(x => x.CourseId) + 1;
                    }

                    Course s = new Course()
                    {
                        CourseId = newCourseId,
                        Name = e.Name,
                        GradeId = e.GradeId,
                        Description = e.Description
                    };

                    await _context.Courses.AddAsync(s);
                    TempData["Message"] = "Course Add successfully";
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.GradeId = new SelectList(_context.Courses, "GradeId", "GradeId", e.GradeId);
            return View("Create", e);
        }

        private bool ClassroomExists(int id)
        {
            return _context.Classrooms.Any(e => e.ClassroomId == id);
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("CourseId,Name,Description,GradeId")] Course course)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(course);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["GradeId"] = new SelectList(_context.Grades, "GradeId", "GradeId", course.GradeId);
        //    return View(course);
        //}

        // GET: Courses/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var course = await _context.Courses.FindAsync(id);
        //    if (course == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["GradeId"] = new SelectList(_context.Grades, "GradeId", "GradeId", course.GradeId);
        //    return View(course);
        //}

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("CourseId,Name,Description,GradeId")] Course course)
        //{
        //    if (id != course.CourseId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(course);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CourseExists(course.CourseId))
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
        //    ViewData["GradeId"] = new SelectList(_context.Grades, "GradeId", "GradeId", course.GradeId);
        //    return View(course);
        //}

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Grade)
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.CourseId == id);
        }
    }
}

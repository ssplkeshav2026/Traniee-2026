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
        // GET: Courses/Create
        public IActionResult Create()
        {
            ViewBag.GradeId = new SelectList(_context.Grades, "GradeId", "GradeId");

            return View(new CourseViewModel());
        }
        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(CourseViewModel e)
        {
            if (ModelState.IsValid)
            {
                int newCourseId = 1;

                if (await _context.Courses.AnyAsync())
                {
                    newCourseId = await _context.Courses.MaxAsync(x => x.CourseId) + 1;
                }

                Course course = new Course()
                {
                    CourseId = newCourseId,
                    Name = e.Name,
                    Description = e.Description,
                    GradeId = e.GradeId
                };

                await _context.Courses.AddAsync(course);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewBag.GradeId = new SelectList(_context.Grades, "GradeId", "GradeID", e.GradeId);

            return View(e);
        }


        // GET: Courses/Edit/5
        // GET Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCourse(CourseViewModel e)
        {
            if (ModelState.IsValid)
            {
                var exist = await _context.Courses
                    .FirstOrDefaultAsync(x => x.CourseId == e.CourseId);

                // UPDATE
                if (exist != null)
                {
                    exist.Name = e.Name;
                    exist.Description = e.Description;
                    exist.GradeId = e.GradeId;

                    TempData["Message"] = "Course Updated Successfully";
                }

                // CREATE
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
                        Description = e.Description,
                        GradeId = e.GradeId
                    };

                    await _context.Courses.AddAsync(s);

                    TempData["Message"] = "Course Added Successfully";
                }

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            ViewData["GradeId"] = new SelectList(_context.Grades, "GradeId", "GradeId", e.GradeId);

            return View("Create", e);
        }


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

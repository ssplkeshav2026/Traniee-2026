using First.netAssigmnet.Models;
using First.netAssigmnet.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.netAssigmnet.Controllers
{
    public class CoursesController : Controller
    {
        private readonly SchooErpContext context;

        public CoursesController(SchooErpContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var schooErpContext = context.Courses.Include(c => c.Grade);
            return View(await schooErpContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await context.Courses
                .Include(c => c.Grade)
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpGet]
        public IActionResult Create()
        {
           

            var viewModel = new CourseViewModel();
            viewModel.Grades = context.Grades.ToList();
            return View("Views/Courses/Edit.cshtml", viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseViewModel model)
        {
            model.Grades = context.Grades.ToList();
            if (ModelState.IsValid)
            {
                Course course = new Course()
                {
                    CourseId = model.CourseId,
                    Name = model.Name,
                    Description = model.Description,
                    GradeId = model.GradeId
                };

                if (model.CourseId > 0)
                {
                    context.Update(course);
                    await context.SaveChangesAsync();
                }
                else
                {
                    context.Add(course);
                    await context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            else
                return View("Views/Courses/Edit.cshtml", model);




        }

        public async Task<IActionResult> Edit(int? id)
        {
            var course = context.Courses.FirstOrDefault(x => x.CourseId == id);

            if (course == null)
                return NotFound();

            var model = new CourseViewModel
            {
                CourseId = course.CourseId,
                Name = course.Name,
                Description = course.Description,
                GradeId = course.GradeId,
                Grades = context.Grades.ToList()
            };

            ViewData["GradeId"] = new SelectList(
                  context.Grades,
                  "GradeId",
                 "GradeId",
                 model.GradeId);

            return View("Edit", model);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, Course course)
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

      
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await context.Courses
                .Include(c => c.Grade)
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRows(int id)
        {
            var course = await context.Courses.FindAsync(id);
            if (course != null)
            {
                context.Courses.Remove(course);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return context.Courses.Any(e => e.CourseId == id);
        }
    }
}


 
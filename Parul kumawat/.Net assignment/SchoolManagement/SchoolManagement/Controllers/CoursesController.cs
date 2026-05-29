
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;
using SchoolManagement.Models.ViewModel;

public class CoursesController : Controller
{
    private readonly SchoolErpContext _context;

    public CoursesController(SchoolErpContext context)
    {
        _context = context;
    }

    // GET: COURSES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Courses.ToListAsync());
    }

    // GET: COURSES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var course = await _context.Courses
            .FirstOrDefaultAsync(m => m.CourseId == id);
        if (course == null)
        {
            return NotFound();
        }

        return View(course);
    }

    // GET: COURSES/Create
    public async Task<IActionResult> CreateAsync(int? id)
    {
        ViewBag.GradeId = new SelectList(_context.Grades, "GradeId", "GradeId");
        if (id == null || id == 0)
        {
            return View(new CourseEditViewModel());
        }
        var courseData = await _context.Courses.FirstOrDefaultAsync(x => x.CourseId == id);
        if (courseData == null)
        {
            return NotFound();
        }
        CourseEditViewModel courseEditViewModel = new CourseEditViewModel()
        {
            CourseId = courseData.CourseId,
            Name = courseData.Name,
            Description = courseData.Description,
            GradeId = courseData.GradeId,
        };
        return View(courseEditViewModel);
    }

    // POST: COURSES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CourseEditViewModel courseEditViewModel)
    {
        if (ModelState.IsValid)
        {
            var isCourseExist = _context.Courses.FirstOrDefault(x => x.CourseId == courseEditViewModel.CourseId);
            if (isCourseExist != null)
            {
                isCourseExist.CourseId = courseEditViewModel.CourseId;
                isCourseExist.Name = courseEditViewModel.Name;
                isCourseExist.Description = courseEditViewModel.Description;
                isCourseExist.GradeId = courseEditViewModel.GradeId;
                TempData["Message"] = "Course Updated Successfully";

            }
            else
            {
                int newCouseId = 1;
                if (_context.Courses.Any())
                {
                    newCouseId = await _context.Courses.MaxAsync(x => x.CourseId) + 1;
                }

                Course course = new Course()
                {
                    CourseId = newCouseId,
                    Name = courseEditViewModel.Name,
                    Description = courseEditViewModel.Description,
                    GradeId = courseEditViewModel.GradeId,
                };
                _context.Courses.Add(course);
                TempData["Message"] = "Course Added Successfully";

            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
        return View(courseEditViewModel);
    }

    // GET: COURSES/Edit/5
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
    //    return View(course);
    //}

    // POST: COURSES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Edit(int? id, [Bind("CourseId,Name,Description,GradeId,Grade")] Course course)
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
    //    return View(course);
    //}

    // GET: COURSES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var course = await _context.Courses
            .FirstOrDefaultAsync(m => m.CourseId == id);
        if (course == null)
        {
            return NotFound();
        }

        return View(course);
    }

    // POST: COURSES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course != null)
        {
            _context.Courses.Remove(course);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CourseExists(int? id)
    {
        return _context.Courses.Any(e => e.CourseId == id);
    }
}

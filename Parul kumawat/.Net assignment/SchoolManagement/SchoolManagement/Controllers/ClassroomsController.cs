
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;
using SchoolManagement.Models.ViewModel;
using static System.Collections.Specialized.BitVector32;

public class ClassroomsController : Controller
{
    private readonly SchoolErpContext _context;

    public ClassroomsController(SchoolErpContext context)
    {
        _context = context;
    }

    // GET: CLASSROOMS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Classrooms.ToListAsync());
    }

    // GET: CLASSROOMS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var classroom = await _context.Classrooms
            .FirstOrDefaultAsync(m => m.ClassroomId == id);
        if (classroom == null)
        {
            return NotFound();
        }

        return View(classroom);
    }

    // GET: CLASSROOMS/Create
    public async Task<IActionResult> CreateAsync(int? id)
    {
        ViewBag.GradeId = new SelectList(_context.Grades, "GradeId", "GradeId");

        ViewBag.TeacherId = new SelectList(_context.Teachers, "TeacherId", "TeacherId");

        if(id == null || id == 0)
        {
            return View(new ClassroomEditViewModel());
        }
        var classroomData = await _context.Classrooms.FirstOrDefaultAsync(x => x.ClassroomId == id);
        if(classroomData == null)
        {
            return NotFound();
        }
        ClassroomEditViewModel classroomEdit = new ClassroomEditViewModel()
        {
            ClassroomId = classroomData.ClassroomId,
            ClassroomYear = classroomData.ClassroomYear,
            Section = classroomData.Section,
            Status = classroomData.Status,
            Remarks = classroomData.Remarks,
            GradeId = classroomData.GradeId,
            TeacherId = classroomData.TeacherId,
        };
        ViewData["ActionType"] = "Update";

        return View(classroomEdit);
    }

    // POST: CLASSROOMS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ClassroomEditViewModel classroomEditViewModel)
    {
        if (ModelState.IsValid)
        {
            var isClassroomExist = _context.Classrooms.FirstOrDefault(x => x.ClassroomId == classroomEditViewModel.ClassroomId);
        if (isClassroomExist != null)
        {
                isClassroomExist.ClassroomId = classroomEditViewModel.ClassroomId;
                isClassroomExist.ClassroomYear = classroomEditViewModel.ClassroomYear;
                isClassroomExist.Section = classroomEditViewModel.Section;
                isClassroomExist.Status = classroomEditViewModel.Status;
                isClassroomExist.Remarks = classroomEditViewModel.Remarks;
                isClassroomExist.GradeId = classroomEditViewModel.GradeId;
                isClassroomExist.TeacherId = classroomEditViewModel.TeacherId;

            TempData["Message"] = "Classroom Updated Successfully";

            }
            else
            {
                int newClassroomId = 1;
                if (_context.Classrooms.Any())
                {
                    newClassroomId = await _context.Classrooms.MaxAsync(x => x.ClassroomId) + 1;
                }
                Classroom classroom = new Classroom()
                {
                    ClassroomId = newClassroomId,
                    ClassroomYear = classroomEditViewModel.ClassroomYear,
                    Section = classroomEditViewModel.Section,
                    Status = classroomEditViewModel.Status,
                    Remarks = classroomEditViewModel.Remarks,
                    GradeId = classroomEditViewModel.GradeId,
                    TeacherId = classroomEditViewModel.TeacherId,

                };
                _context.Add(classroom);
                TempData["Message"] = "Classroom Added Successfully";

            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(classroomEditViewModel);
    }

    // GET: CLASSROOMS/Edit/5
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
    //    return View(classroom);
    //}

    // POST: CLASSROOMS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Edit(int? id, [Bind("ClassroomId,ClassroomYear,Section,Status,Remarks,GradeId,TeacherId,Grade,Teacher")] Classroom classroom)
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
    //    return View(classroom);
    //}

    // GET: CLASSROOMS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var classroom = await _context.Classrooms
            .FirstOrDefaultAsync(m => m.ClassroomId == id);
        if (classroom == null)
        {
            return NotFound();
        }

        return View(classroom);
    }

    // POST: CLASSROOMS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var classroom = await _context.Classrooms.FindAsync(id);
        if (classroom != null)
        {
            _context.Classrooms.Remove(classroom);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ClassroomExists(int? id)
    {
        return _context.Classrooms.Any(e => e.ClassroomId == id);
    }
}

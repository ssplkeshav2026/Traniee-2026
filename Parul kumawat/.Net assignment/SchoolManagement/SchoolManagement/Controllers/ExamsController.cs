
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;
using SchoolManagement.Models.ViewModel;

public class ExamsController : Controller
{
    private readonly SchoolErpContext _context;

    public ExamsController(SchoolErpContext context)
    {
        _context = context;
    }

    // GET: EXAMS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Exams.ToListAsync());
    }

    // GET: EXAMS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var exam = await _context.Exams
            .FirstOrDefaultAsync(m => m.ExamId == id);
        if (exam == null)
        {
            return NotFound();
        }

        return View(exam);
    }

    // GET: EXAMS/Create
    public async Task<IActionResult> CreateAsync(int? id)
    {
        ViewBag.ExamTypeId = new SelectList(_context.ExamTypes, "ExamTypeId", "ExamTypeId");
        if (id == null || id == 0)
        {
            return View(new ExamEditViewModel());
        }
        var examData = await _context.Exams.FirstOrDefaultAsync(x => x.ExamId == id);
        if (examData == null)
        {
            return NotFound();
        }
        ExamEditViewModel examEditViewModel = new ExamEditViewModel()
        {
            ExamId = examData.ExamId,
            ExamTypeId = examData.ExamTypeId,
            Name = examData.Name,
            StartDate = examData.StartDate,

        };

        return View(examEditViewModel);
    }

    // POST: EXAMS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ExamEditViewModel examEditViewModel)
    {
        if (ModelState.IsValid)
        {
            var isExamExist = _context.Exams.FirstOrDefault(x => x.ExamId == examEditViewModel.ExamId);
            if (isExamExist != null)
            {
                isExamExist.ExamId = examEditViewModel.ExamId;
                isExamExist.ExamTypeId = examEditViewModel.ExamTypeId;
                isExamExist.Name = examEditViewModel.Name;
                isExamExist.StartDate = examEditViewModel.StartDate;
                TempData["Message"] = "Exam Updated Successfully";

            }
            else
            {
                int newExamId = 1;
                if (_context.Exams.Any())
                {
                    newExamId = await _context.Exams.MaxAsync(x => x.ExamId) + 1;
                }
                Exam exam = new Exam
                {

                    ExamId = newExamId,
                    ExamTypeId = examEditViewModel.ExamTypeId,
                    Name = examEditViewModel.Name,
                    StartDate = examEditViewModel.StartDate,

                };
                _context.Exams.Add(exam);
                TempData["Message"] = "Exam Added Successfully";
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
            return View(examEditViewModel);

        }
     
           
       

    // GET: EXAMS/Edit/5
    //public async Task<IActionResult> Edit(int? id)
    //{
    //    if (id == null)
    //    {
    //        return NotFound();
    //    }

    //    var exam = await _context.Exams.FindAsync(id);
    //    if (exam == null)
    //    {
    //        return NotFound();
    //    }
    //    return View(exam);
    //}

    //// POST: EXAMS/Edit/5
    //// To protect from overposting attacks, enable the specific properties you want to bind to.
    //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Edit(int? id, [Bind("ExamId,ExamTypeId,Name,StartDate,ExamType")] Exam exam)
    //{
    //    if (id != exam.ExamId)
    //    {
    //        return NotFound();
    //    }

    //    if (ModelState.IsValid)
    //    {
    //        try
    //        {
    //            _context.Update(exam);
    //            await _context.SaveChangesAsync();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!ExamExists(exam.ExamId))
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
    //    return View(exam);
    //}

    // GET: EXAMS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var exam = await _context.Exams
            .FirstOrDefaultAsync(m => m.ExamId == id);
        if (exam == null)
        {
            return NotFound();
        }

        return View(exam);
    }

    // POST: EXAMS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var exam = await _context.Exams.FindAsync(id);
        if (exam != null)
        {
            _context.Exams.Remove(exam);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ExamExists(int? id)
    {
        return _context.Exams.Any(e => e.ExamId == id);
    }
}

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
    public class ExamsController : Controller
    {
        private readonly SchooErpContext _context;

        public ExamsController(SchooErpContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var schooErpContext = _context.Exams.Include(e => e.ExamType);
            return View(await schooErpContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.Exams
                .Include(e => e.ExamType)
                .FirstOrDefaultAsync(m => m.ExamId == id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        [HttpGet] // Get: Create
        public IActionResult Create()
        { 
            ExamViewModel viewModel = new ExamViewModel();

            viewModel.ExamTypes = _context.ExamTypes.Where(p => p.ExamTypeId != null).ToList();
            return View("Views/Exams/Edit.cshtml", viewModel);
        }

        
        [HttpPost] // Post : Create & Edit
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExamViewModel model)
        {
            

            model.ExamTypes = _context.ExamTypes.ToList();
            if (ModelState.IsValid)
            {
                Exam exam = new Exam()
                {
                    ExamId = model.ExamId,
                    ExamTypeId = model.ExamTypeId,
                    Name = model.Name,
                    StartDate = model.StartDate
                };

                if (model.ExamId > 0)
                {
                    _context.Update(exam);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.Add(exam);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            else
                return View("Views/Exams/Edit.cshtml", model);
        }


        [HttpGet] // Get : Edit
        public async Task<IActionResult> Edit(int? id)
        {
            var exam = _context.Exams.FirstOrDefault(x => x.ExamId == id);

            if (exam == null)
                return NotFound();

            var model = new ExamViewModel
            {
                ExamId = exam.ExamId,
                ExamTypeId = exam.ExamTypeId,
                Name = exam.Name,
                StartDate = exam.StartDate,
                ExamTypes = _context.ExamTypes.ToList()
            };

            ViewData["ParentId"] = new SelectList(
                  _context.ExamTypes,
                  "ExamTypeId",
                 "ExamtypeId",
                 model.ExamTypeId);

            return View("Edit", model);
        }


            //        [HttpPost]
            //        [ValidateAntiForgeryToken]
            //        public async Task<IActionResult> Edit(int? id, Exam model)
            //        {
            //            if (id != model.ExamId)
            //            {
            //                return NotFound();
            //            }
            //            if (ModelState.IsValid)
            //            {
            //                try
            //                {
            //                    _context.Update(model);
            //                    await _context.SaveChangesAsync();
            //    }
            //                catch (DbUpdateConcurrencyException)
            //                {
            //                    if (!ExamExists(model.ExamId))
            //                    {
            //                        return NotFound();
            //}
            //                    else
            //{
            //    throw;
            //}
            //                }
            //                return RedirectToAction(nameof(Index));
            //            }
            //            ViewData["ExamTypeId"] = new SelectList(_context.ExamTypes, "ExamTypeId", "ExamTypeId", model.ExamTypeId);
            //return View(model);
            //        }




        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.Exams
                .Include(e => e.ExamType)
                .FirstOrDefaultAsync(m => m.ExamId == id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRows(int id)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam != null)
            {
                _context.Exams.Remove(exam);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamExists(int id)
        {
            return _context.Exams.Any(e => e.ExamId == id);
        }
    }
}

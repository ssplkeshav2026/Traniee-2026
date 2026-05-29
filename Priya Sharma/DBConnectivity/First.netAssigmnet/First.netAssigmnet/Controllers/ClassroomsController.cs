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
    public class ClassroomsController : Controller
    {
        private readonly SchooErpContext context;

        public ClassroomsController(SchooErpContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var schooErpContext = context.Classrooms.Include(c => c.Grade).Include(c => c.Teacher);
            return View(await schooErpContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classroom = await context.Classrooms
                .Include(c => c.Grade)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.ClassroomId == id);
            if (classroom == null)
            {
                return NotFound();
            }
            
            return View(classroom);
        }

        [HttpGet]
        public IActionResult Create()
        {
           
            ClassroomViewModel viewModel = new ClassroomViewModel();
            viewModel.Grades = context.Grades.ToList();

            viewModel.Teachers = context.Teachers.ToList();

            return View("Views/Classrooms/Edit.cshtml", viewModel);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClassroomViewModel model)
        {

            model.Grades = context.Grades.ToList();
            model.Teachers = context.Teachers.ToList();

            if (ModelState.IsValid)
            {
                Classroom classroom = new Classroom()
                {
                    ClassroomId = model.ClassroomId,
                    Year = model.Year,
                    GradeId = model.GradeId,
                    Section = model.Section,
                    Status = model.Status,
                    Remarks = model.Remarks,
                    TeacherId = model.TeacherId
                };

                if (model.ClassroomId > 0)
                {
                    context.Update(classroom);
                    await context.SaveChangesAsync();
                }
                else
                {
                    context.Add(classroom);
                    await context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            else
                return View("Views/Classrooms/Edit.cshtml", model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var classroom = context.Classrooms.FirstOrDefault(x => x.ClassroomId == id);

            if (classroom == null)
                return NotFound();

            var model = new ClassroomViewModel
            {
                ClassroomId = classroom.ClassroomId,
                Year = classroom.Year,
                GradeId = classroom.GradeId,
                Section = classroom.Section,
                Status = classroom.Status,
                Remarks = classroom.Remarks,
                TeacherId = classroom.TeacherId,
                Grades = context.Grades.ToList(),
                Teachers = context.Teachers.ToList()

            };

            ViewData["GradeId"] = new SelectList(
                  context.Grades,
                  "GradeId",
                 "GradeId",
                 model.GradeId);
            ViewData["TeacherId"] = new SelectList(
                context.Teachers,
                "TeachersId",
                "TeacherId",
                model.TeacherId);

            return View("Edit", model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classroom = await context.Classrooms
                .Include(c => c.Grade)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.ClassroomId == id);
            if (classroom == null)
            {
                return NotFound();
            }

            return View(classroom);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRows(int id)
        {
            var classroom = await context.Classrooms.FindAsync(id);
            if (classroom != null)
            {
                context.Classrooms.Remove(classroom);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassroomExists(int id)
        {
            return context.Classrooms.Any(e => e.ClassroomId == id);
        }
    }
}



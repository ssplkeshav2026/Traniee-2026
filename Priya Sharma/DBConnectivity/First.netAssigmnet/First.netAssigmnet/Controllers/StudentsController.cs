using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using First.netAssigmnet.Models;
using First.netAssigmnet.ViewModel;

namespace First.netAssigmnet.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchooErpContext context;

        public StudentsController(SchooErpContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var schooErpContext = context.Students.Include(s => s.Parent);
            return View(await schooErpContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await context.Students
                .Include(s => s.Parent)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new StudentViewModel();


            viewModel.Parents = context.Parents.ToList();
            return View("Views/Students/Edit.cshtml", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Parents = context.Parents.ToList();


                Student student = new Student()
                {
                    StudentId = model.StudentId,
                    Email = model.Email,
                    Password = model.Password,
                    Fname = model.Fname,
                    Lname = model.Lname,
                    Dob = model.Dob,
                    Phone = model.Phone,
                    Mobile = model.Mobile,
                    ParentId = model.ParentId,
                    DateOfJoin = model.DateOfJoin,
                    Status = model.Status,
                    LastLoginDate = model.LastLoginDate,
                    LastLoginIp = model.LastLoginIp
                };

                if (model.StudentId > 0)
                {
                    context.Students.Update(student);
                    await context.SaveChangesAsync();
                }
                else
                {

                    context.Students.Add(student);
                    await context.SaveChangesAsync();
                }


                return RedirectToAction(nameof(Index));


            }
            else
                return View("Views/Students/Edit.cshtml", model);

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = context.Students.FirstOrDefault(x => x.StudentId == id);

            if (student == null)
                return NotFound();

            var model = new StudentViewModel
            {
                StudentId = student.StudentId,
                Email = student.Email,
                Password = student.Password,
                Fname = student.Fname,
                Lname = student.Lname,
                Dob = student.Dob,
                Phone = student.Phone,
                Mobile = student.Mobile,
                ParentId = student.ParentId,
                DateOfJoin = student.DateOfJoin,
                Status = student.Status,
                LastLoginDate = student.LastLoginDate,
                LastLoginIp = student.LastLoginIp,
                Parents = context.Parents.ToList()
            };

            ViewData["ParentId"] = new SelectList(
                  context.Parents,
                  "ParentId",
                 "Email",
                 model.ParentId);

            return View("Edit", model);
        }

        /*        [HttpPost]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> Edit(int? id, StudentViewModelcs model)
                {
                    if (id != model.StudentId)
                    {
                        return NotFound();
                    }

                    if (ModelState.IsValid)
                    {
                        try
                        {
                            var student = await _context.Students.FindAsync(id);

                            if (student == null)
                            {
                                return NotFound();
                            }

                            student.Email = model.Email;
                            student.Password = model.Password;
                            student.Fname = model.Fname;
                            student.Lname = model.Lname;
                            student.Dob = model.Dob;
                            student.Phone = model.Phone;
                            student.Mobile = model.Mobile;
                            student.ParentId = model.ParentId;
                            student.DateOfJoin = model.DateOfJoin;
                            student.Status = model.Status;
                            student.LastLoginDate = model.LastLoginDate;
                            student.LastLoginIp = model.LastLoginIp;

                            _context.Update(student);
                            await _context.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!StudentExists(model.StudentId))
                            {
                                return NotFound();
                            }
                            else
                            {
                                throw;
                            }
                        }

                        return RedirectToAction(nameof(Index));
                    }

                    return View(model);
                }
        */

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await context.Students
                .Include(s => s.Parent)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var student = await context.Students.FindAsync(id);
            if (student != null)
            {
                context.Students.Remove(student);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int? id)
        {
            return context.Students.Any(e => e.StudentId == id);
        }
    }
}

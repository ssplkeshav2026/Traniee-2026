
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModels;

namespace SchoolManagementSystem.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolDbContext _context;

        public StudentsController(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var schoolDbContext = _context.Students.Include(s => s.Parent);
            return View(await schoolDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _context.Students
                .Include(s => s.Parent)
                .FirstOrDefaultAsync(m => m.StudentId == id);

            if (student == null)
                return NotFound();

            return View(student);
        }


        // GET: Students/Create
        public IActionResult Create()
        {
            StudentViewModel vm = new StudentViewModel();

            vm.ParentList = _context.Parents
                .Select(p => new SelectListItem
                {
                    Value = p.ParentId.ToString(),
                    Text = p.ParentId.ToString()
                })
                .ToList();

            return View(vm);
        }


        // POST: Students/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(StudentViewModel vm)
        {
            ModelState.Remove("ParentList");

            if (!ModelState.IsValid)
            {
                vm.ParentList = _context.Parents
                    .Select(p => new SelectListItem
                    {
                        Value = p.ParentId.ToString(),
                        Text = p.ParentId.ToString()
                    })
                    .ToList();

                return View("Create", vm);
            }

            if (vm.StudentId == 0)
            {
                Student student = new Student()
                {
                    Email = vm.Email,
                    Passwordd = vm.Passwordd,
                    Fname = vm.Fname,
                    Lname = vm.Lname,
                    Dob = vm.Dob,
                    Phone = vm.Phone,
                    Mobile = vm.Mobile,
                    ParentId = vm.ParentId,
                    Status = vm.Status,
                    LastLoginDate = vm.LastLoginDate,
                    LastLoginIp = vm.LastLoginIp
                };

                _context.Students.Add(student);
            }
            else
            {
                var student = await _context.Students.FindAsync(vm.StudentId);

                if (student == null)
                    return NotFound();

                student.Email = vm.Email;
                student.Passwordd = vm.Passwordd;
                student.Fname = vm.Fname;
                student.Lname = vm.Lname;
                student.Dob = vm.Dob;
                student.Phone = vm.Phone;
                student.Mobile = vm.Mobile;
                student.ParentId = vm.ParentId;
                student.Status = vm.Status;
                student.LastLoginDate = vm.LastLoginDate;
                student.LastLoginIp = vm.LastLoginIp;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            StudentViewModel vm = new StudentViewModel()
            {
                StudentId = student.StudentId,
                Email = student.Email,
                Passwordd = student.Passwordd,
                Fname = student.Fname,
                Lname = student.Lname,
                Dob = student.Dob,
                Phone = student.Phone,
                Mobile = student.Mobile,
                ParentId = student.ParentId,
                Status = student.Status,
                LastLoginDate = student.LastLoginDate,
                LastLoginIp = student.LastLoginIp,

                ParentList = _context.Parents
                    .Select(p => new SelectListItem
                    {
                        Value = p.ParentId.ToString(),
                        Text = p.ParentId.ToString()
                    })
                    .ToList()
            };

            return View("Create", vm);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _context.Students
                .Include(s => s.Parent)
                .FirstOrDefaultAsync(m => m.StudentId == id);

            if (student == null)
                return NotFound();

            return View(student);
        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student != null)
                _context.Students.Remove(student);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
    }
}
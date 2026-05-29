using DatabaseFirstApproach.Models;
using DatabaseFirstApproach.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DatabaseFirstApproach.Controllers
{
    public class StudentController : Controller
    {
        private readonly SchooErpContext context;

        public StudentController(SchooErpContext Context)
        {
            context = Context;
        }
        public IActionResult Index()
        {
            var stdData = context.Students.ToList();
            return View(stdData);
        }
        public async Task<IActionResult> Create(int? id)
        {
            ViewBag.ParentId = new SelectList(context.Parents, "ParentId", "ParentId");
            if(id == null || id == 0)
            {
                return View(new EditOrCreate());
            }
            var studentData =await context.Students.FirstOrDefaultAsync(x=>x.StudentId==id);
            if (studentData == null) 
            {
                return NotFound();
            }
            EditOrCreate e = new EditOrCreate()
            {
                StudentId = studentData.StudentId,
                Email = studentData.Email,
                Password = studentData.Password,
                Fname = studentData.Fname,
                Lname = studentData.Lname,
                Dob = studentData.Dob,
                Phone = studentData.Phone,
                Mobile = studentData.Mobile,
                ParentId = studentData.ParentId,
                DateOfJoin = studentData.DateOfJoin,
                Status = studentData.Status,
                LastLoginDate = studentData.LastLoginDate,
                LastLoginIp = studentData.LastLoginIp
            };
            return View(e);

        }
        //[HttpPost]
        //public async Task<IActionResult> Create(Student std)
        //{
        //    await context.Students.AddAsync(std);
        //    await context.SaveChangesAsync();
        //    return RedirectToAction("Index", "Home");

        //}
        public IActionResult Details()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Details(int? id)
        {
            if (id == null || context.Students == null)
            {
                return NotFound();
            }
            var stdData = context.Students.FirstOrDefault(x => x.StudentId == id);
            return View(stdData);

        }
        //public IActionResult Edit(int id)
        //{
        //    var stdData = context.Students.Find(id);
        //    return View(stdData);
        //}
        //[HttpPost]
        //public IActionResult Edit(int? id, Student std)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        context.Students.Update(std);
        //        context.SaveChanges();
        //        return RedirectToAction("Index", "Home");
        //    }
        //    return View(std);
        //}


        public IActionResult Delete(int? id)
        {
            var stdData = context.Students.Find(id);


            return View(stdData);

        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfimed(int? id)
        {
            var stdData = context.Students.Find(id);
            if (stdData != null)
            {
                context.Students.Remove(stdData);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");

            }
            return RedirectToAction("Index", "Home");

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public async Task<IActionResult> EditStudent(EditOrCreate e)
        {
            if (ModelState.IsValid)
            {
                var exist = await context.Students.FirstOrDefaultAsync(x => x.StudentId == e.StudentId);

                if (exist != null)
                {
                    exist.Email = e.Email;
                    exist.Password = e.Password;
                    exist.Fname = e.Fname;
                    exist.Lname = e.Lname;
                    exist.Dob = e.Dob;
                    exist.Phone = e.Phone;
                    exist.Mobile = e.Mobile;
                    exist.ParentId = e.ParentId;
                    exist.DateOfJoin = e.DateOfJoin;
                    exist.Status = e.Status;
                    exist.LastLoginDate = e.LastLoginDate;
                    exist.LastLoginIp = e.LastLoginIp;

                    TempData["Message"] = "Student Update successfully";
                }
                else
                {
                    int newStudentId = 1;

                    if (await context.Students.AnyAsync())
                    {
                        newStudentId = await context.Students.MaxAsync(x => x.StudentId) + 1;
                    }

                    Student s = new Student()
                    {
                        StudentId = newStudentId,
                        Email = e.Email,
                        Password = e.Password,
                        Fname = e.Fname,
                        Lname = e.Lname,
                        Dob = e.Dob,
                        Phone = e.Phone,
                        Mobile = e.Mobile,
                        ParentId = e.ParentId,
                        DateOfJoin = e.DateOfJoin,
                        Status = e.Status,
                        LastLoginDate = e.LastLoginDate,
                        LastLoginIp = e.LastLoginIp
                    };

                    await context.Students.AddAsync(s);
                    TempData["Message"] = "Student Add successfully";
                }

                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ParentId = new SelectList(context.Parents, "ParentId", "ParentId", e.ParentId);
            return View("Create", e);
        }
    }
}

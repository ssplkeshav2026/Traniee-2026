using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;
using SchoolManagement.Models.ViewModels;
using System.Diagnostics;

namespace SchoolManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly SchooErpContext context;

        public HomeController(SchooErpContext Context)
        {
            context = Context;
        }

        // INDEX
        public IActionResult Index()
        {
            var stdData = context.Students.ToList();
            return View(stdData);
        }

        // CREATE GET
        public async Task<IActionResult> Create(int? id)
        {
            ViewBag.ParentId = new SelectList(context.Parents, "ParentId", "ParentId");

            if (id == null || id == 0)
            {
                return View(new CreateStudentViewModel());
            }

            var studentData = await context.Students
                .FirstOrDefaultAsync(x => x.StudentId == id);

            if (studentData == null)
            {
                return NotFound();
            }

            CreateStudentViewModel std = new CreateStudentViewModel()
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
                LastLoginIp = studentData.LastLoginIp,
                Image = studentData.Image
            };

            return View(std);
        }

        // CREATE & EDIT POST
        [HttpPost]
        public async Task<IActionResult> EditStudent(CreateStudentViewModel e)
        {
            if (ModelState.IsValid)
            {
                string? fileName = null;

                // IMAGE UPLOAD
                if (e.ImageFile != null)
                {
                    string uploadFolder = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot/uploads");

                    // Create folder if not exists
                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }

                    // Unique image name
                    fileName = Guid.NewGuid().ToString()
                               + Path.GetExtension(e.ImageFile.FileName);

                    string filePath = Path.Combine(uploadFolder, fileName);

                    // Save image in folder
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await e.ImageFile.CopyToAsync(stream);
                    }
                }

                var exist = await context.Students
                    .FirstOrDefaultAsync(x => x.StudentId == e.StudentId);

                // UPDATE
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

                    // Update image
                    if (fileName != null)
                    {
                        // delete old image
                        if (!string.IsNullOrEmpty(exist.Image))
                        {
                            string oldImagePath = Path.Combine(
                                Directory.GetCurrentDirectory(),
                                "wwwroot/uploads",
                                exist.Image);

                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                        }

                        exist.Image = fileName;
                    }

                    TempData["Message"] = "Student Updated Successfully";
                }

                // INSERT
                else
                {
                    int newStudentId = 1;

                    if (await context.Students.AnyAsync())
                    {
                        newStudentId = await context.Students
                            .MaxAsync(x => x.StudentId) + 1;
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
                        LastLoginIp = e.LastLoginIp,

                        // save image name in db
                        Image = fileName
                    };

                    await context.Students.AddAsync(s);

                    TempData["Message"] = "Student Added Successfully";
                }

                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            ViewBag.ParentId = new SelectList(
                context.Parents,
                "ParentId",
                "ParentId",
                e.ParentId);

            return View("Create", e);
        }

        // DETAILS
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stdData = context.Students
                .FirstOrDefault(x => x.StudentId == id);

            if (stdData == null)
            {
                return NotFound();
            }

            return View(stdData);
        }

        // DELETE GET
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stdData = context.Students.Find(id);

            if (stdData == null)
            {
                return NotFound();
            }

            return View(stdData);
        }

        // DELETE POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var student = await context.Students.FindAsync(id);

            if (student != null)
            {
                // delete image from folder
                if (!string.IsNullOrEmpty(student.Image))
                {
                    string imagePath = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot/uploads",
                        student.Image);

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }

                context.Students.Remove(student);

                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0,
            Location = ResponseCacheLocation.None,
            NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id
                            ?? HttpContext.TraceIdentifier
            });
        }
    }
}
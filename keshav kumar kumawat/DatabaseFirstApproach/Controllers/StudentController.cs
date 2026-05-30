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

        //[HttpPost]
        //public IActionResult Index(IFormFile file)
        //{
        //    if (file != null && file.Length > 0)
        //    {
        //        // uploads folder path
        //        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

        //        // agar folder exist nahi karta toh create karo
        //        if (!Directory.Exists(uploadsFolder))
        //        {
        //            Directory.CreateDirectory(uploadsFolder);
        //        }

        //        // full file path
        //        var filePath = Path.Combine(uploadsFolder, file.FileName);

        //        // file ko uploads folder me save karo
        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            file.CopyTo(stream);
        //        }

        //        // database me save karo
        //        using (var memoryStream = new MemoryStream())
        //        {
        //            file.CopyTo(memoryStream);

        //            var imageUpload = new Student
        //            {
        //                FileName = file.FileName,
        //                ImageData = memoryStream.ToArray()
        //            };

        //            context.Students.Add(imageUpload);
        //            context.SaveChanges();
        //        }

        //        ViewBag.Message = "File uploaded successfully!";
        //    }
        //    else
        //    {
        //        ViewBag.Message = "Please select a file to upload.";
        //    }

        //    return View("Index");
        //}
        public async Task<IActionResult> Create(int? id)
        {
            ViewBag.ParentId = new SelectList(context.Parents, "ParentId", "ParentId");
            if (id == null || id == 0)
            {
                return View(new EditOrCreate());
            }
            var studentData = await context.Students.FirstOrDefaultAsync(x => x.StudentId == id);
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
                LastLoginIp = studentData.LastLoginIp,
                Image = studentData.Image
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
        public async Task<IActionResult> EditStudent(EditOrCreate e, IFormFile file)
        {
            ViewBag.ParentId = new SelectList(context.Parents, "ParentId", "ParentId", e.ParentId);

            if (!ModelState.IsValid)
            {
                return View("Create", e);
            }

            string? imagePath = null;

            if (file != null && file.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                imagePath = "/uploads/" + fileName;
            }

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

                if (imagePath != null)
                {
                    exist.Image = imagePath;
                }

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
                    LastLoginIp = e.LastLoginIp,
                    Image = imagePath
                };

                await context.Students.AddAsync(s);
                TempData["Message"] = "Student Add successfully";
            }

            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

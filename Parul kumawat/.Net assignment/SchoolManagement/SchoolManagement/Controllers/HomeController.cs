using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;
using SchoolManagement.Models.ViewModel;
using System.Diagnostics;

namespace SchoolManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly SchoolErpContext schoolContext;
        public HomeController(SchoolErpContext _schoolContext)
        {
            schoolContext = _schoolContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create(int? id)
        {
            ViewBag.ParentId = new SelectList(schoolContext.Parents, "ParentId", "ParentId");

            if (id == null || id == 0)
            {
                return View(new EditViewModel());
            }
            var studentData = schoolContext.Students.FirstOrDefault(x => x.StudentId == id);
            if (studentData == null)
            {
                return NotFound();
            }
            EditViewModel edit = new EditViewModel()
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
            return View(edit);
        }
        //public IActionResult UpdateStudents(int id)
        //{
        //    var data = schoolContext.Students.FirstOrDefault(x => x.StudentId == id);
        //    return View(data);
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //[HttpPost]
        //public IActionResult CreateStudent(Student student)
        //{
        //    var isExist = schoolContext.Students.FirstOrDefault(x => x.StudentId == student.StudentId);
        //    var isEmailExist = schoolContext.Students.FirstOrDefault(x => x.Email == student.Email);

        //    if (isExist != null)
        //    {
        //        TempData["Message"] = "Student is already exist of this Id";
        //        return View("Create", student);

        //    }
        //    if (isEmailExist != null)
        //    {
        //        TempData["Message"] = "This email is already exist";
        //        return View("Create", student);

        //    }
        //    if (ModelState.IsValid)
        //    {
        //        schoolContext.Students.Add(student);
        //        schoolContext.SaveChanges();
        //        return RedirectToAction("DisplayStudents");
        //    }
        //    return View("Create", student);
        //}


        public IActionResult DisplayStudents()
        {
            var data = schoolContext.Students.ToList();
            return View(data);
        }

        //[HttpPost]
        //public IActionResult UpdateStudent(Student student)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        schoolContext.Students.Update(student);
        //        schoolContext.SaveChanges();
        //        return RedirectToAction("DisplayStudents");
        //    }
        //    return View(student);

        //}


        [HttpPost]
        public IActionResult CreateAndEditStudent(EditViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                var existingStudent = schoolContext.Students.FirstOrDefault(x => x.StudentId == editViewModel.StudentId);

                if (existingStudent != null)
                {
               
                existingStudent.Email = editViewModel.Email;
                existingStudent.Password = editViewModel.Password;
                existingStudent.Fname = editViewModel.Fname;
                existingStudent.Lname = editViewModel.Lname;
                existingStudent.Dob = editViewModel.Dob;
                existingStudent.Phone = editViewModel.Phone;
                existingStudent.Mobile = editViewModel.Mobile;
                existingStudent.ParentId = editViewModel.ParentId;
                existingStudent.DateOfJoin = editViewModel.DateOfJoin;
                existingStudent.Status = editViewModel.Status;
                existingStudent.LastLoginDate = editViewModel.LastLoginDate;
                existingStudent.LastLoginIp = editViewModel.LastLoginIp;

                TempData["Message"] = "Student Updated Successfully";
            }
            else
            {

                var isEmailExist = schoolContext.Students.FirstOrDefault(x => x.Email == editViewModel.Email);

                
                if (isEmailExist != null)
                {
                    TempData["Message"] = "This email is already exist";
                    return View("Create", editViewModel);

                }
                    int newStudentId = 1;
                    if (schoolContext.Students.Any())
                    {
                        newStudentId = schoolContext.Students.Max(x => x.StudentId) + 1;
                    }

                    Student student = new Student()
                {
                    StudentId = newStudentId,
                    Email = editViewModel.Email,
                    Password = editViewModel.Password,
                    Fname = editViewModel.Fname,
                    Lname = editViewModel.Lname,
                    Dob = editViewModel.Dob,
                    Phone = editViewModel.Phone,
                    Mobile = editViewModel.Mobile,
                    ParentId = editViewModel.ParentId,
                    DateOfJoin = editViewModel.DateOfJoin,
                    Status = editViewModel.Status,
                    LastLoginDate = editViewModel.LastLoginDate,
                    LastLoginIp = editViewModel.LastLoginIp
                };


                schoolContext.Students.Add(student);
                TempData["Message"] = "Student Added Successfully";


            }
            schoolContext.SaveChanges();
            return RedirectToAction("DisplayStudents");


        }
            return View("Create", editViewModel);

    }

        public IActionResult DeleteStudent(int id)
        {
            var data = schoolContext.Students.FirstOrDefault(x => x.StudentId == id);
            if(data == null)
            {
                TempData["Message"] = "Student does not exist";
            }
            else
            {
                schoolContext.Students.Remove(data);
                schoolContext.SaveChanges();
                TempData["Message"] = "Student deleted successfully";

            }
            return RedirectToAction("DisplayStudents");
        }
    }
}
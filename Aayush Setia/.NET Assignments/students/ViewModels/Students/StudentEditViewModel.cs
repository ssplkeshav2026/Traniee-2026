using students.Models;
using System.ComponentModel.DataAnnotations;

namespace students.ViewModels.Students
{
    public class StudentEditViewModel
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? FName { get; set; }

        public string? LName { get; set; }

        public DateOnly? DOB { get; set; }

        public string? Phone { get; set; }

        public string? Mobile { get; set; }

        public int? ParentId { get; set; }

        public DateOnly? DateOfJoin { get; set; }

        public bool? Status { get; set; }

        public DateOnly? LastLoginDate { get; set; }

        public string? LastLoginIP { get; set; }

        public List<string> Names { get; set; } = new List<string>();


        #region References

        public virtual Parent? Parent { get; set; }

        #endregion


        public StudentEditViewModel ToViewModel(Student student)
        {
            return new StudentEditViewModel()
            {
                StudentId = student.StudentId,
                Email = student.Email,
                Password = student.Password,
                FName = student.FName,
                LName = student.LName,
                DOB = student.DOB,
                Phone = student.Phone,
                Mobile = student.Mobile,
                ParentId = student.ParentId,
                DateOfJoin = student.DateOfJoin,
                Status = student.Status,
                LastLoginDate = student.LastLoginDate,
                LastLoginIP = student.LastLoginIP
            };
        }


        public Student ToDataModel(StudentEditViewModel viewModel)
        {
            return new Student()
            {
                StudentId = viewModel.StudentId,
                Email = viewModel.Email,
                Password = viewModel.Password,
                FName = viewModel.FName,
                LName = viewModel.LName,
                DOB = viewModel.DOB,
                Phone = viewModel.Phone,
                Mobile = viewModel.Mobile,
                ParentId = viewModel.ParentId,
                DateOfJoin = viewModel.DateOfJoin,
                Status = viewModel.Status,
                LastLoginDate = viewModel.LastLoginDate,
                LastLoginIP = viewModel.LastLoginIP
            };
        }
    }
}
using students.Models;

namespace students.ViewModels.Classrooms
{
    public class ClassroomEditViewModel
    {
        public int ClassroomId { get; set; }

        public int? Year { get; set; }

        public int? GradeId { get; set; }

        public string? Section { get; set; }

        public bool? Status { get; set; }

        public string? Remarks { get; set; }

        public int? TeacherId { get; set; }

        public virtual Teacher? Teacher { get; set; }

        public ClassroomEditViewModel ToViewModel(Classroom classroom)
        {
            return new ClassroomEditViewModel()
            {
                ClassroomId = classroom.ClassroomId,
                Year = classroom.Year,
                GradeId = classroom.GradeId,
                Section = classroom.Section,
                Status = classroom.Status,
                Remarks = classroom.Remarks,
                TeacherId = classroom.TeacherId
            };
        }

        public Classroom ToDataModel()
        {
            return new Classroom()
            {
                ClassroomId = this.ClassroomId,
                Year = this.Year,
                GradeId = this.GradeId,
                Section = this.Section,
                Status = this.Status,
                Remarks = this.Remarks,
                TeacherId = this.TeacherId
            };
        }
    }
}
namespace SchoolManagement.Models.ViewModels
{
    public class ClassRoomViewModel
    {
        public int ClassroomId { get; set; }

        public DateOnly? Year { get; set; }

        public string? Section { get; set; }

        public bool? Status { get; set; }

        public string? Remarks { get; set; }

        public int? TeacherId { get; set; }

        public int? GradeId { get; set; }

        public virtual Grade? Grade { get; set; }

        public virtual Teacher? Teacher { get; set; }

    }
}

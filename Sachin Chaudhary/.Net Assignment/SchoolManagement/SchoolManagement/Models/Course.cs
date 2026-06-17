using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? GradeId { get; set; }

    public virtual ICollection<ExamResult> ExamResults { get; set; } = new List<ExamResult>();

    public virtual Grade? Grade { get; set; }
}

using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Models;

public partial class ExamType
{
    public int ExamTypeId { get; set; }

    public string? Name { get; set; }

    public string? Descc { get; set; }

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();
}

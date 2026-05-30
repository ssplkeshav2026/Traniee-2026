using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class Exam
{
    public int ExamId { get; set; }

    public int? ExamTypeId { get; set; }

    public string? Name { get; set; }

    public DateOnly? StartDate { get; set; }

    public virtual ICollection<ExamResult> ExamResults { get; set; } = new List<ExamResult>();

    public virtual ExamType? ExamType { get; set; }
}

using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Models;

public partial class Exam
{
    public int ExamId { get; set; }

    public int? ExamTypeId { get; set; }

    public string? Name { get; set; }

    public DateOnly? StartDate { get; set; }

    public virtual ExamType? ExamType { get; set; }
}

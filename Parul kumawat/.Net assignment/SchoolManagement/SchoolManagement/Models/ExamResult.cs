using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class ExamResult
{
    public int ExamId { get; set; }

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public double Marks { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Exam? Exam { get; set; }

    public virtual Student? Student { get; set; }
}

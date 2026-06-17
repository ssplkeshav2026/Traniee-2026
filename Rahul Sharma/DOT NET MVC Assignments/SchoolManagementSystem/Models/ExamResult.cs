using System;
using System.Collections.Generic;


namespace SchoolManagementSystem.Models;

public partial class ExamResult
{
    public int? ExamId { get; set; }

    public int? StudentId { get; set; }

 
    public int? CourceId { get; set; }

    
    public string? Marks { get; set; }

    public virtual Cource? Cource { get; set; }

    public virtual Exam? Exam { get; set; }

    public virtual Student? Student { get; set; }
}
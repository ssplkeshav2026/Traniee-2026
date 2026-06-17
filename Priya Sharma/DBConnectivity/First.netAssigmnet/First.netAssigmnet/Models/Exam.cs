using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace First.netAssigmnet.Models;

public partial class Exam
{
    [Required]
    public int? ExamId { get; set; }
    [Required]
    public int? ExamTypeId { get; set; }

    public string? Name { get; set; }

    public DateOnly? StartDate { get; set; }

    public virtual ExamType? ExamType { get; set; }
}

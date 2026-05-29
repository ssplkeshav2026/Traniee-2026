using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models;

public partial class Exam
{
    public int ExamId { get; set; }
    [Required]
    public int? ExamTypeId { get; set; }
    [Required]
    [MaxLength(20)]
    public string? Name { get; set; }
    [DataType(DataType.Date)]

    public DateOnly? StartDate { get; set; }

    public virtual ExamType? ExamType { get; set; }
}

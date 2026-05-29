using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models;

public partial class Course
{
    public int CourseId { get; set; }
    [Required]
    [MaxLength(50)]
    public string? Name { get; set; }
    [Required]
    [MaxLength(50)]
    public string? Description { get; set; }

    public int? GradeId { get; set; }

    public virtual Grade? Grade { get; set; }
}

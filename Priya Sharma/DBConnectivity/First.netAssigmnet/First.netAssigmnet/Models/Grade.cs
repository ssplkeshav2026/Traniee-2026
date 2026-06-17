using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace First.netAssigmnet.Models;

public partial class Grade
{
    [Required]
    public int GradeId { get; set; }
    [Required]
    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Classroom> Classrooms { get; set; } = new List<Classroom>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}

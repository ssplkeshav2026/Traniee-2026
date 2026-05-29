using System;
using System.Collections.Generic;

namespace DatabaseFirstApproach.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public string? Name { get; set; }

    public string? Desc { get; set; }

    public virtual ICollection<Classroom> Classrooms { get; set; } = new List<Classroom>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}

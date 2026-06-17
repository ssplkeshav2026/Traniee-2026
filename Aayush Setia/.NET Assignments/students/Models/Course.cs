using System;
using System.Collections.Generic;

namespace students.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? GradeId { get; set; }
}

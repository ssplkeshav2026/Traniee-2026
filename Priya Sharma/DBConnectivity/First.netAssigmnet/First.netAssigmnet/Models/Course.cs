using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace First.netAssigmnet.Models;

public partial class Course
{
    
    public int? CourseId { get; set; }
    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? GradeId { get; set; }

    public virtual Grade? Grade { get; set; } = null;
}

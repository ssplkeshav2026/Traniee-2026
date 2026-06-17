using System;
using System.Collections.Generic;
using Microsoft.Build.Framework;


namespace First.netAssigmnet.Models;

public partial class ClassroomStudent
{
    [Required]
    public int? ClassroomId { get; set; }
    [Required]
    public int? StudentId { get; set; }

    public virtual Classroom? Classroom { get; set; }

    public virtual Student? Student { get; set; }
}

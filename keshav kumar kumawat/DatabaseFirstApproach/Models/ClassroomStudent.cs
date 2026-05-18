using System;
using System.Collections.Generic;

namespace DatabaseFirstApproach.Models;

public partial class ClassroomStudent
{
    public int? ClassroomId { get; set; }

    public int? StudentId { get; set; }

    public virtual Classroom? Classroom { get; set; }

    public virtual Student? Student { get; set; }
}

using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Models;

public partial class Classroom
{
    public int ClassroomId { get; set; }

    public int? Yearr { get; set; }

    public int? GradeId { get; set; }

    public string? Selection { get; set; }

    public bool? Status { get; set; }

    public string? Remark { get; set; }

    public int? TeacherId { get; set; }

    public virtual Grade? Grade { get; set; }

    public virtual Teacher? Teacher { get; set; }
}

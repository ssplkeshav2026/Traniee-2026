using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Models;

public partial class Attendance
{
    public DateOnly? Datee { get; set; }

    public int? StudentId { get; set; }

    public bool? Status { get; set; }

    public string? Remark { get; set; }

    public virtual Student? Student { get; set; }
}

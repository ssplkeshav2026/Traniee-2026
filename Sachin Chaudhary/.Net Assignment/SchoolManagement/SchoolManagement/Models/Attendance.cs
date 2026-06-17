using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class Attendance
{
    public DateOnly? Date { get; set; }

    public int? StudentId { get; set; }

    public bool? Status { get; set; }

    public string? Remark { get; set; }

    public virtual Student? Student { get; set; }
}

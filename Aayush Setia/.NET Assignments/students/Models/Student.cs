using System;
using System.Collections.Generic;

namespace students.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? FName { get; set; }

    public string? LName { get; set; }

    public DateOnly? DOB { get; set; }

    public string? Phone { get; set; }

    public string? Mobile { get; set; }

    public int? ParentId { get; set; }

    public DateOnly? DateOfJoin { get; set; }

    public bool? Status { get; set; }

    public DateOnly? LastLoginDate { get; set; }

    public string? LastLoginIP { get; set; }

    public virtual Parent? Parent { get; set; }
}

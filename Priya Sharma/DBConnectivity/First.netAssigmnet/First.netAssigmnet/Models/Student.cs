using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace First.netAssigmnet.Models;

public partial class Student
{
    public int StudentId { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }

    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public DateOnly? Dob { get; set; }

    public string? Phone { get; set; }

    public string? Mobile { get; set; }

    public int? ParentId { get; set; }

    public DateOnly? DateOfJoin { get; set; }

    public bool? Status { get; set; }

    public DateOnly? LastLoginDate { get; set; }

    public string? LastLoginIp { get; set; }

    public virtual Parent? Parent { get; set; }

}

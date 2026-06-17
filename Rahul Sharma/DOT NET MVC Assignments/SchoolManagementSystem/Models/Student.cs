using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models;

public partial class Student
{
    [Required]
    public int StudentId { get; set; }

    [Required]
    public string? Fname { get; set; }
    public string? Email { get; set; }

    public string? Passwordd { get; set; }

    //public string? Fname { get; set; }

    public string? Lname { get; set; }

    public DateOnly? Dob { get; set; }

    public string? Phone { get; set; }

    public string? Mobile { get; set; }

    public int? ParentId { get; set; }

    public bool? Status { get; set; }

    public DateOnly? LastLoginDate { get; set; }

    public string? LastLoginIp { get; set; }

    public virtual Parent? Parent { get; set; }
}

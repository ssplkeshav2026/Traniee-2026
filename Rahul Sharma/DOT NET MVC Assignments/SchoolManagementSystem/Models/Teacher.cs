using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Models;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string? Email { get; set; }

    public string? Passwordd { get; set; }

    public string? Fname { get; set; }

    public string? Laname { get; set; }

    public DateOnly? Dob { get; set; }

    public string? Phone { get; set; }

    public string? Mobile { get; set; }

    public int? ParentId { get; set; }

    public bool? Status { get; set; }

    public DateOnly? LastLoginDate { get; set; }

    public string? LastLoginIp { get; set; }

    public virtual ICollection<Classroom> Classrooms { get; set; } = new List<Classroom>();
}

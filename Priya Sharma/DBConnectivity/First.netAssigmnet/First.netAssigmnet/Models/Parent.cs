using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace First.netAssigmnet.Models;

public partial class Parent
{
    [Required]
    public int? ParentId { get; set; }
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
    [Required]

    public string? Fname { get; set; }

    public string? Lname { get; set; }
    [Required]
    public DateOnly? Dob { get; set; }
    [Required]

    public string? Phone { get; set; }

    public string? Mobile { get; set; }
    [Required]

    public DateOnly DateOfJoin { get; set; }

    public bool? Status { get; set; }
    public DateOnly? LastLoginDate { get; set; }

    public string? LastLoginIp { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}

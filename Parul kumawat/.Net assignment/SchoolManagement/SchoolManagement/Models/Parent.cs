using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models;

public partial class Parent
{
    public int ParentId { get; set; }

    [EmailAddress]
    [Required]
    public string? Email { get; set; }
    [Required]

    public string? Password { get; set; }

    [Required]
    [MaxLength(50)]
    public string? Fname { get; set; }

    [MaxLength(50)]
    public string? Lname { get; set; }

    [DataType(DataType.Date)]

    public DateOnly? Dob { get; set; }
    [Phone(ErrorMessage = "Invalid phone number format.")]

    public string? Phone { get; set; }
    [Phone(ErrorMessage = "Invalid phone number format.")]

    public string? Mobile { get; set; }

    public bool? Status { get; set; }
    [DataType(DataType.Date)]

    public DateOnly? LastLoginDate { get; set; }
    [DataType(DataType.Date)]

    public string? LastLoginIp { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}

using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public string? Name { get; set; }

    public string? Descc { get; set; }

    public virtual ICollection<Classroom> Classrooms { get; set; } = new List<Classroom>();

    public virtual ICollection<Cource> Cources { get; set; } = new List<Cource>();
}

using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Models;

public partial class Cource
{
    public int CourceId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? GradeId { get; set; }

    public virtual Grade? Grade { get; set; }
}

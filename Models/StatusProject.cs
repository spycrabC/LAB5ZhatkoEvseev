using System;
using System.Collections.Generic;

namespace LAB5ZhatkoEvseev.Models;

public partial class StatusProject
{
    public int PkStatusProject { get; set; }

    public string? NameProject { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}

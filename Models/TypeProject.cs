using System;
using System.Collections.Generic;

namespace LAB5ZhatkoEvseev.Models;

public partial class TypeProject
{
    public int PkTypeProject { get; set; }

    public string? NameType { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}

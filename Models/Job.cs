using System;
using System.Collections.Generic;

namespace LAB5ZhatkoEvseev.Models;

public partial class Job
{
    public int PkJob { get; set; }

    public string? NameJob { get; set; }

    public virtual ICollection<Employe> Employes { get; set; } = new List<Employe>();
}

using System;
using System.Collections.Generic;

namespace LAB5ZhatkoEvseev.Models;

public partial class CostCategory
{
    public int PkCostCategory { get; set; }

    public string? NameCategory { get; set; }

    public virtual ICollection<ProjectCost> ProjectCosts { get; set; } = new List<ProjectCost>();
}

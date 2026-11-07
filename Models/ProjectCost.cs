using System;
using System.Collections.Generic;

namespace LAB5ZhatkoEvseev.Models;

public partial class ProjectCost
{
    public int PkProjectCost { get; set; }

    public int? FkProject { get; set; }

    public int? FkCostCategory { get; set; }

    public double? Amount { get; set; }

    public virtual CostCategory? FkCostCategoryNavigation { get; set; }

    public virtual Project? FkProjectNavigation { get; set; }
}

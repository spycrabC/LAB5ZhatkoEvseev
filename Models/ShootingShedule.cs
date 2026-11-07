using System;
using System.Collections.Generic;

namespace LAB5ZhatkoEvseev.Models;

public partial class ShootingShedule
{
    public int PkShootingShedule { get; set; }

    public int? FkTabnomer { get; set; }

    public int? FkProject { get; set; }

    public virtual Project? FkProjectNavigation { get; set; }

    public virtual Employe? FkTabnomerNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace LAB5ZhatkoEvseev.Models;

public partial class Platform
{
    public int PkPlatform { get; set; }

    public string? Adres { get; set; }

    public double? Sumarendi { get; set; }

    public int? Vmestimost { get; set; }

    public int? FkTypeplatform { get; set; }

    public virtual FkTypeplatform? FkTypeplatformNavigation { get; set; }
}

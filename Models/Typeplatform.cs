using System;
using System.Collections.Generic;

namespace LAB5ZhatkoEvseev.Models;

public partial class Typeplatform
{
    public int PkTypeplatform { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Platform> Platforms { get; set; } = new List<Platform>();
}

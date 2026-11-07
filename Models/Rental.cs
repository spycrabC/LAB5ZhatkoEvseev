using System;
using System.Collections.Generic;

namespace LAB5ZhatkoEvseev.Models;

public partial class Rental
{
    public int PkRental { get; set; }

    public int? FkProject { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public int? TheaterCount { get; set; }

    public double? BoxOffice { get; set; }

    public double? ViewerRating { get; set; }

    public virtual Project? FkProjectNavigation { get; set; }
}

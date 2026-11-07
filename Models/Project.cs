using System;
using System.Collections.Generic;

namespace LAB5ZhatkoEvseev.Models;

public partial class Project
{
    public int PkProject { get; set; }

    public string? NameProject { get; set; }

    public int? FkTypeProject { get; set; }

    public int? FkGenreProject { get; set; }

    public DateOnly? DateStart { get; set; }

    public DateOnly? DateEnd { get; set; }

    public int? FkStatusProject { get; set; }

    public int? AgeRating { get; set; }

    public virtual GenreProject? FkGenreProjectNavigation { get; set; }

    public virtual StatusProject? FkStatusProjectNavigation { get; set; }

    public virtual TypeProject? FkTypeProjectNavigation { get; set; }

    public virtual ICollection<SemachnaaGroup> SemachnaaGroups { get; set; } = new List<SemachnaaGroup>();

    public virtual ICollection<ShootingShedule> ShootingShedules { get; set; } = new List<ShootingShedule>();
}

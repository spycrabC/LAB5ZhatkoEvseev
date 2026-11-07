using System;
using System.Collections.Generic;

namespace LAB5ZhatkoEvseev.Models;

public partial class GenreProject
{
    public int PkGenreProject { get; set; }

    public string? NameGenre { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}

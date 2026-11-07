using System;
using System.Collections.Generic;

namespace LAB5ZhatkoEvseev.Models;

public partial class Employe
{
    public int PkEmploye { get; set; }

    public string? Surname { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }

    public string? Patronymic { get; set; }

    public int? FkJob { get; set; }

    public double? Bid { get; set; }

    public string? Phone { get; set; }

    public virtual Job? FkJobNavigation { get; set; }

    public virtual ICollection<SemachnaaGroup> SemachnaaGroups { get; set; } = new List<SemachnaaGroup>();

    public virtual ICollection<ShootingShedule> ShootingShedules { get; set; } = new List<ShootingShedule>();
}

using System;
using System.Collections.Generic;

namespace HRAPPv1.Models;

public partial class ColaboradorType
{
    public string IdType { get; set; } = null!;

    public string? Type { get; set; }

    public virtual ICollection<ColaboradorCompetency> ColaboradorCompetencies { get; } = new List<ColaboradorCompetency>();
}

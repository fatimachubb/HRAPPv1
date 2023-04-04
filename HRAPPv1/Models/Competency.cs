using System;
using System.Collections.Generic;

namespace HRAPPv1.Models;

public partial class Competency
{
    public string IdCompetencie { get; set; } = null!;

    public string? CompetencieDescrip { get; set; }

    public virtual ICollection<ColaboradorCompetency> ColaboradorCompetencies { get; } = new List<ColaboradorCompetency>();

    public virtual ICollection<Question> Questions { get; } = new List<Question>();
}

using System;
using System.Collections.Generic;

namespace HRAPPv1.Models;

public partial class Question
{
    public string IdQuestion { get; set; } = null!;

    public string? DescripQuestion { get; set; }

    public string? CompetencieIdCompetencie { get; set; }

    public virtual Competency? CompetencieIdCompetencieNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace HRAPPv1.Models;

public partial class ColaboradorCompetency
{
    public string Idcc { get; set; } = null!;

    public string? ColaboradorTypeIdType { get; set; }

    public string? CompetencieIdCompetencie { get; set; }

    public virtual ColaboradorType? ColaboradorTypeIdTypeNavigation { get; set; }

    public virtual Competency? CompetencieIdCompetencieNavigation { get; set; }
}

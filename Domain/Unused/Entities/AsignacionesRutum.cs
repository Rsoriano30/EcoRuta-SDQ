using System;
using System.Collections.Generic;

namespace Domain.Unused.Entities;

public partial class AsignacionesRutum
{
    public int AsignacionId { get; set; }

    public int? HorarioId { get; set; }

    public int? ChoferId { get; set; }

    public int? CamionId { get; set; }

    public virtual Camione? Camion { get; set; }

    public virtual Chofere? Chofer { get; set; }

    public virtual Horario? Horario { get; set; }
}
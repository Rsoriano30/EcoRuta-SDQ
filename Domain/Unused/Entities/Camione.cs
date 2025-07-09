using System;
using System.Collections.Generic;

namespace Domain.Unused.Entities;

public partial class Camione
{
    public int CamionId { get; set; }

    public string? Placa { get; set; }

    public string? Modelo { get; set; }

    public int? Año { get; set; }

    public virtual ICollection<AsignacionesRutum> AsignacionesRuta { get; set; } = new List<AsignacionesRutum>();
}

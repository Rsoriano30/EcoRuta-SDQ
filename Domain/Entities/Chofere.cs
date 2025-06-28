using System;
using System.Collections.Generic;

namespace Domain.Entities;
public partial class Chofere
{
    public int ChoferId { get; set; }

    public string? Nombre { get; set; }

    public string? Cedula { get; set; }

    public virtual ICollection<AsignacionesRutum> AsignacionesRuta { get; set; } = new List<AsignacionesRutum>();
}

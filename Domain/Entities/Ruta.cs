using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Ruta
{
    public int RutaId { get; set; }

    public string? NombreRuta { get; set; }

    public string? PuntoInicio { get; set; }

    public string? PuntoFinal { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();
}

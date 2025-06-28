using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Horario
{
    public int HorarioId { get; set; }

    public int? RutaId { get; set; }

    public TimeOnly? HoraSalida { get; set; }

    public TimeOnly? HoraLlegada { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public virtual ICollection<AsignacionesRutum> AsignacionesRuta { get; set; } = new List<AsignacionesRutum>();

    public virtual Ruta? Ruta { get; set; }
}

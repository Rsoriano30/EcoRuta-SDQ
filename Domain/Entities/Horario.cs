using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Horario
{
    public int HorarioId { get; set; }

    public TimeOnly? HoraSalida { get; set; }

    public TimeOnly? HoraLlegada { get; set; }

    public string? DiaInicio { get; set; }

    public string? DiaFin { get; set; }

    public virtual ICollection<AsignacionesRutum> AsignacionesRuta { get; set; } = new List<AsignacionesRutum>();
}

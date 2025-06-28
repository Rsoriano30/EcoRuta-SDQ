using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class LogsActividad
{
    public int LogId { get; set; }

    public int? UsuarioId { get; set; }

    public string? Accion { get; set; }

    public DateTime? FechaHora { get; set; }

    public virtual Usuario? Usuario { get; set; }
}

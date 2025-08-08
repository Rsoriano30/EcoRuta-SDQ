using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Correo { get; set; }

    public string? Contraseña { get; set; }

    public string? TipoUsuario { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<LogsActividad> LogsActividads { get; set; } = new List<LogsActividad>();

    public virtual ICollection<Reporte> Reportes { get; set; } = new List<Reporte>();
}

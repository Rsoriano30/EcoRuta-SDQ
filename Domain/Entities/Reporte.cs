using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Reporte
{
    public int ReporteId { get; set; }

    public int? UsuarioId { get; set; }

    public string? Titulo { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaHora { get; set; }

    public string? Estado { get; set; }

    public virtual Usuario? Usuario { get; set; }
}

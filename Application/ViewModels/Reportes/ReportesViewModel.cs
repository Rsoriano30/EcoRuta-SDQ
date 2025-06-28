using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Reportes
{
    public class ReportesViewModel
    {
        public int ReporteId { get; set; }

        public int? UsuarioId { get; set; }

        public string? Titulo { get; set; }

        public string? Descripcion { get; set; }

        public DateTime? FechaHora { get; set; }

        public string? Estado { get; set; }
    }
}

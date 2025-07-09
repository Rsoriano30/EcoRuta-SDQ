using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Asignaciones
{
    public class AsignacionesDetailsViewModel
    {
        public int AsignacionId { get; set; }

        public int? RutaId { get; set; }
        public string? NombreRuta { get; set; }

        public int? HorarioId { get; set; }
        public TimeOnly? HoraSalida { get; set; }
        public TimeOnly? HoraLlegada { get; set; }

        public int? CamionId { get; set; }
        public string? PlacaCamion { get; set; }

        public int? ChoferId { get; set; }
        public string? NombreChofer { get; set; }
        public string? CedulaChofer { get; set; }
    }
}

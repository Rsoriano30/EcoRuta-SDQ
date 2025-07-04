using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Rutas
{
    public class RutaHandlerViewModel
    {
        public string? NombreRuta { get; set; }

        public string? PuntoInicio { get; set; }

        public string? PuntoFinal { get; set; }

        public bool? Estado { get; set; }
    }
}

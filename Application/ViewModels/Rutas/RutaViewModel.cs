using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Rutas
{
    public class RutaViewModel : RutaSaveViewModel
    {
        public int RutaId { get; set; }
        public double? InicioLat { get; set; }
        public double? InicioLng { get; set; }
        public double? FinLat { get; set; }
        public double? FinLng { get; set; }
    }
}

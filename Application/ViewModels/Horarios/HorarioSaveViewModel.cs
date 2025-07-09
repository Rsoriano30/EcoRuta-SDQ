using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Horarios
{
    public class HorarioSaveViewModel
    {
        public TimeOnly? HoraSalida { get; set; }

        public TimeOnly? HoraLlegada { get; set; }

        public string? DiaInicio { get; set; }

        public string? DiaFin { get; set; }
    }
}

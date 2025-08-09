using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Choferes
{
    public class ChoferSaveViewModel
    {
        public string? Nombre { get; set; }

        [RegularExpression(@"^\d{3}-?\d{7}-?\d{1}$", ErrorMessage = "La cédula debe tener este formato XXX-XXXXXXX-X")]
        public string? Cedula { get; set; }
    }
}

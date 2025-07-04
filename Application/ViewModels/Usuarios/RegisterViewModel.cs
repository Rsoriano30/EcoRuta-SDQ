using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Usuarios
{
    public class RegisterViewModel
    {
        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? Correo { get; set; }

        public string? Contraseña { get; set; }

        public string? TipoUsuario { get; set; }

        public DateTime? FechaRegistro { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels.Reportes;
using Application.ViewModels.Rutas;
using Domain.Entities;

namespace Application.Intefaces.Services
{
    public interface IRutasService : IGenericService<RutaHandlerViewModel, RutaViewModel, Ruta>
    {

    }
}

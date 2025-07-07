using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels.Camiones;
using Domain.Entities;

namespace Application.Intefaces.Services
{
    public interface ICamionesService : IGenericService<CamionSaveViewModel, CamionViewModel, Camione>
    {
    }
}

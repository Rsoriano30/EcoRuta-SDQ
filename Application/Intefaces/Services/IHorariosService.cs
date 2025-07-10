using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels.Horarios;
using Domain.Entities;

namespace Application.Intefaces.Services
{
    public interface IHorariosService : IGenericService<HorarioSaveViewModel, HorarioViewModel, Horario>
    {
    }
}

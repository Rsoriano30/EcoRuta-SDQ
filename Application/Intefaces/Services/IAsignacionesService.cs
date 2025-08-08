using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels.Asignaciones;
using Domain.Entities;

namespace Application.Intefaces.Services
{
    public interface IAsignacionesService : IGenericService<AsignacionSaveViewModel, AsignacionViewModel, AsignacionesRutum>
    {
        Task<List<AsignacionesDetailsViewModel>> GetAllWithJoin();
        Task<AsignacionesDetailsViewModel> GetWithJoin(int id);
    }
}
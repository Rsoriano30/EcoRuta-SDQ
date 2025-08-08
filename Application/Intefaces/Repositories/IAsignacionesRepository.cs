using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Application.Intefaces.Repositories
{
    public interface IAsignacionesRepository : IGenericRepository<AsignacionesRutum>
    {
        Task<List<AsignacionesRutum>> GetAllWithJoin();
        Task<AsignacionesRutum> GetWithJoin(int id);
    }
}

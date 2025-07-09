using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Intefaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Structure.Context;

namespace Structure.Repositories
{
    public class AsignacionesRepository : GenericRepository<AsignacionesRutum>, IAsignacionesRepository
    {
        private readonly EcoRutaContext _context;

        public AsignacionesRepository(EcoRutaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<AsignacionesRutum>> GetAllWithJoin()
        {
            return await _context.AsignacionesRuta.Include(p => p.Ruta)
                                                  .Include(p => p.Horario)
                                                  .Include(p => p.Camion)
                                                  .Include(p => p.Chofer)
                                                  .ToListAsync();
        }

        public async Task<AsignacionesRutum> GetWithJoin(int id)
        {
            return await _context.AsignacionesRuta.Where(p => p.AsignacionId == id)
                                                 .Include(p => p.Ruta)
                                                 .Include(p => p.Horario)
                                                 .Include(p => p.Camion)
                                                 .Include(p => p.Chofer)
                                                 .FirstAsync();
        }
    }
}

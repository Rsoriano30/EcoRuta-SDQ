using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Intefaces.Repositories;
using Domain.Entities;
using Structure.Context;

namespace Structure.Repositories
{
    public class RutasRepository : GenericRepository<Ruta>, IRutasRepository
    {
        private readonly EcoRutaContext _context;
        public RutasRepository(EcoRutaContext context) : base(context)
        {
            _context = context;
        }
    }
}

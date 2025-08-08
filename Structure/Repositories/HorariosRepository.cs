using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Intefaces.Repositories;
using Structure.Context;

namespace Structure.Repositories
{
    public class HorariosRepository : GenericRepository<Domain.Entities.Horario>, IHorariosRepository
    {
        private readonly EcoRutaContext _context;

        public HorariosRepository(EcoRutaContext context) : base(context)
        {
            _context = context;
        }
    }
}

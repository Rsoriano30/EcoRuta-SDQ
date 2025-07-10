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
    public class ReportesRepository : GenericRepository<Reporte>, IReportesRepository
    {
        private readonly EcoRutaContext _context;
        public ReportesRepository(EcoRutaContext context) : base(context)
        {
            _context = context;
        }
    }
}

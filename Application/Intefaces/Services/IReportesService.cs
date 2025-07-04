using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels.Reportes;
using Domain.Entities;

namespace Application.Intefaces.Services
{
    public interface IReportesService : IGenericService<ReporteSaveViewModel, ReporteViewModel, Reporte>
    {
    }
}

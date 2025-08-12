using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Intefaces.Repositories;
using Application.Intefaces.Services;
using Application.ViewModels.Reportes;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ReportesService : GenericService<ReporteSaveViewModel, ReporteViewModel, Reporte>, IReportesService
    {
        private readonly IReportesRepository _repository;
        private readonly IMapper _mapper;

        public ReportesService(IReportesRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ReporteViewModel>> GetCurrentMothReportesPendientes()
        {
            var reportes = await _repository.GetQuery()
                .Where(i => i.Estado == "Pendiente" &&
                            i.FechaHora.HasValue &&
                            i.FechaHora.Value.Month == DateTime.Now.Month &&
                            i.FechaHora.Value.Year == DateTime.Now.Year)
                .Select(i => new Reporte
                {
                    ReporteId = i.ReporteId,
                    UsuarioId = i.UsuarioId,
                    Titulo = i.Titulo,
                    Descripcion = i.Descripcion,
                    FechaHora = i.FechaHora,
                    Comentario = i.Comentario,
                    Estado = i.Estado,
                    Latitud = i.Latitud,
                    Longitud = i.Longitud
                })
                .ToListAsync();

            return _mapper.Map<List<ReporteViewModel>>(reportes);
        }

        public async Task<List<ReporteViewModel>> GetByUsuarioId(int usuarioId)
        {
            var reportes = await _repository.GetQuery()
                .Where(i => i.UsuarioId == usuarioId)
                .Select(i => new Reporte
                {
                    ReporteId = i.ReporteId,
                    UsuarioId = i.UsuarioId,
                    Titulo = i.Titulo,
                    Descripcion = i.Descripcion,
                    FechaHora = i.FechaHora,
                    Comentario = i.Comentario,
                    Estado = i.Estado,
                    Latitud = i.Latitud,
                    Longitud = i.Longitud
                })
                .ToListAsync();

            return _mapper.Map<List<ReporteViewModel>>(reportes);
        }
    }
}







//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Application.Intefaces.Repositories;
//using Application.Intefaces.Services;
//using Application.ViewModels.Reportes;
//using AutoMapper;
//using Domain.Entities;
//using Microsoft.EntityFrameworkCore;

//namespace Application.Services
//{
//    public class ReportesService : GenericService<ReporteSaveViewModel, ReporteViewModel, Reporte>, IReportesService
//    {
//        private readonly IReportesRepository _repository;
//        private readonly IMapper _mapper;

//        public ReportesService(IReportesRepository repository, IMapper mapper) : base(repository, mapper)
//        {
//            _repository = repository;
//            _mapper = mapper;
//        }

//        public async Task<List<ReporteViewModel>> GetCurrentMothReportesPendientes()
//        {
//            var query = _repository.GetQuery();
//            var reportes = query.Where(i => i.Estado == "Pendiente" &&
//                                            i.FechaHora.HasValue &&
//                                            i.FechaHora.Value.Month == DateTime.Now.Month &&
//                                            i.FechaHora.Value.Year == DateTime.Now.Year)
//            .Select(i => new Reporte
//            {
//                ReporteId = i.ReporteId,
//                UsuarioId = i.UsuarioId,
//                Titulo = i.Titulo,
//                Descripcion = i.Descripcion,
//                FechaHora = i.FechaHora,
//                Comentario = i.Comentario,
//                Estado = i.Estado,
//                Latitud = i.Latitud,
//                Longitud = i.Longitud
//            }).ToListAsync();

//            return _mapper.Map<List<ReporteViewModel>>(reportes);
//        }

//        public async Task<List<ReporteViewModel>> GetByUsuarioId(int usuarioId)
//        {
//            var reportes = _repository.GetQuery()
//                .Where(i => i.UsuarioId == usuarioId)
//                .Select(i => new ReporteViewModel
//                {
//                    ReporteId = i.ReporteId,
//                    UsuarioId = i.UsuarioId,
//                    Titulo = i.Titulo,
//                    Descripcion = i.Descripcion,
//                    FechaHora = i.FechaHora,
//                    Comentario = i.Comentario,
//                    Estado = i.Estado,
//                    Latitud = i.Latitud,
//                    Longitud = i.Longitud
//                })
//                .ToListAsync();

//            return await reportes.ConfigureAwait(false);
//        }

//    }
//}

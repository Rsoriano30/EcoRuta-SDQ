using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Intefaces.Repositories;
using Application.Intefaces.Services;
using Application.ViewModels.Reportes;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class ReportesService : GenericService<ReportesHandlerViewModel, ReportesViewModel, Reporte>, IReportesService
    {
        private readonly IReportesRepository _repository;
        private readonly IMapper _mapper;

        public ReportesService(IReportesRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}

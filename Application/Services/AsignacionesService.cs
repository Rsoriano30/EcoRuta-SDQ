using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Intefaces.Repositories;
using Application.Intefaces.Services;
using Application.ViewModels.Asignaciones;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class AsignacionesService : GenericService<AsignacionSaveViewModel, AsignacionViewModel, AsignacionesRutum>, IAsignacionesService
    {
        private readonly IAsignacionesRepository _repository;
        private readonly IMapper _mapper;

        public AsignacionesService(IAsignacionesRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}

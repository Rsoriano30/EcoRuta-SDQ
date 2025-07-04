using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Intefaces.Repositories;
using Application.Intefaces.Services;
using Application.ViewModels.Reportes;
using Application.ViewModels.Rutas;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class RutasService : GenericService<RutaHandlerViewModel, RutaViewModel, Ruta>, IRutasService
    {
        private readonly IRutasRepository _repository;
        private readonly IMapper _mapper;

        public RutasService(IRutasRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}

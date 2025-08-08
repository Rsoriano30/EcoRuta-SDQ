using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Intefaces.Repositories;
using Application.Intefaces.Services;
using Application.ViewModels.Camiones;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class CamionesService : GenericService<CamionSaveViewModel, CamionViewModel, Camione>, ICamionesService
    {
        private readonly ICamionesRepository _repository;
        private readonly IMapper _mapper;

        public CamionesService(ICamionesRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}

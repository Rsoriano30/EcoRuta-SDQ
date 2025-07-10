using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Intefaces.Repositories;
using Application.Intefaces.Services;
using Application.ViewModels.Horarios;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class HorariosService : GenericService<HorarioSaveViewModel, HorarioViewModel, Horario>, IHorariosService
    {
        private readonly IHorariosRepository _repository;
        private readonly IMapper _mapper;

        public HorariosService(IHorariosRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}

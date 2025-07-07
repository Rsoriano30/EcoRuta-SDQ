using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Intefaces.Repositories;
using Application.Intefaces.Services;
using Application.ViewModels.Choferes;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class ChoferesService : GenericService<ChoferSaveViewModel, ChoferViewModel, Chofere>, IChoferesService
    {
        private readonly IChoferesRepository _repository;
        private readonly IMapper _mapper;

        public ChoferesService(IChoferesRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}

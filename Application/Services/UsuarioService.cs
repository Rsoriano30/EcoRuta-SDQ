using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Intefaces.Repositories;
using Application.Intefaces.Services;
using Application.ViewModels.Usuarios;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class UsuarioService : GenericService<RegisterViewModel, LoginViewModel, Usuario>, IUsuarioService
    {
        private readonly IUsuariosRepository _repository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuariosRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Usuario> GetByEmailAndPasswordAsync(string email, string password)
        {
            return await _repository.GetByEmailAndPasswordAsync(email, password);
        }
    }
}

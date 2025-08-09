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
using Application.ViewModels.Admin;

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

        public async Task<Usuario> GetByEmailAsync(string email)
        {
            return await _repository.GetByEmailAsync(email);
        }

        public async Task<EstadisticasDashboardViewModel> ObtenerEstadisticasDashboardAsync()
        {
            var usuarios = await _repository.GetAllAsync();
            return new EstadisticasDashboardViewModel
            {
                TotalUsuarios = usuarios.Count,
                TotalAdministradores = usuarios.Count(u => u.TipoUsuario == "Administrador"),
                TotalRutas = usuarios.Count(u => u.TipoUsuario == "Usuario")
            };
        }
    }
}
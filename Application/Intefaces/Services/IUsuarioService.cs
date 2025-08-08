using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels.Usuarios;
using Domain.Entities;

namespace Application.Intefaces.Services
{
    public interface IUsuarioService : IGenericService<RegisterViewModel, LoginViewModel, Usuario>
    {
        Task<Usuario> GetByEmailAsync(string email);
    }
}

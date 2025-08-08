using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Intefaces.Repositories;
using Application.ViewModels.Usuarios;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Structure.Context;

namespace Structure.Repositories
{
    public class UsuariosRepository : GenericRepository<Usuario>, IUsuariosRepository
    {
        private readonly EcoRutaContext _context;
        public UsuariosRepository(EcoRutaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Usuario> GetByEmailAsync(string email)
        {
            Usuario? user = await _context.Usuarios
                .Where(u => u.Correo == email)
                .Select(u => new Usuario
                {
                    Nombre = u.Nombre,
                    Correo = u.Correo,
                    TipoUsuario = u.TipoUsuario,
                    UsuarioId = u.UsuarioId,
                    Contraseña = u.Contraseña
                })
                .FirstOrDefaultAsync();

            return user;
        }
    }
}

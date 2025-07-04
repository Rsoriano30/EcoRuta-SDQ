using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Intefaces.Repositories;
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

        public async Task<bool> GetByEmailAndPasswordAsync(string email, string password)
        {
            bool succes;

            return await _context.Usuarios.AnyAsync(u => u.Correo == email 
            && /*u.PasswordHash == password*/ u.Contraseña == password);

        }
    }
}

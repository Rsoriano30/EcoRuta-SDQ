using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Application.Intefaces.Repositories
{
    public interface IUsuariosRepository : IGenericRepository<Usuario>
    {
        Task<bool> GetByEmailAndPasswordAsync(string email, string password);
    }
}
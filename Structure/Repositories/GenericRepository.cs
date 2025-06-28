using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Structure.Context;
using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Structure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly EcoRutaContext _context;

        public GenericRepository(EcoRutaContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual IQueryable<TEntity> GetQuery()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public virtual async Task UpdateAsync(TEntity entity, int id)
        {
            var entry = await _context.Set<TEntity>().FindAsync(id);

            _context.Entry(entry).CurrentValues.SetValues(entity);

            await _context.SaveChangesAsync();
        }
    }
}

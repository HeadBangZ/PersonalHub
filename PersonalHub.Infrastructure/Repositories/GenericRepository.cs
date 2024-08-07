using Microsoft.EntityFrameworkCore;
using PersonalHub.Application.Contracts.Repositories;
using PersonalHub.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalHub.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly PersonalHubDbContext _context;

        public GenericRepository(PersonalHubDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(Guid id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            IQueryable<T> query = _context.Set<T>();

            var navigationProperties = _context.Model.FindEntityType(typeof(T))
                .GetNavigations()
                .Select(n => n.Name);

            foreach (var prop in navigationProperties)
            {
                query = query.Include(prop);
            }

            return await query.ToListAsync();
        }

        public async Task<T?> GetAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

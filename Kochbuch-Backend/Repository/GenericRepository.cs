using Kochbuch_Backend.Contracts;
using Kochbuch_Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Kochbuch_Backend.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly KochbuchDbContext _context;

        public GenericRepository(KochbuchDbContext context)
        {
            this._context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id is null)
            {
                return null;
            }
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task DeleteAsync(int id)
        {
           var entity = await GetAsync(id);
            _context.Set<T>().Remove(entity);

        }

        public async Task<bool> Exisits(int id)
        {
            var entity = await GetAsync(id);   
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
           return await _context.Set<T>().ToListAsync();    
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

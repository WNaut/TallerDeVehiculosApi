using ApplicationCore.Data;
using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _applicationDbContext.Set<T>().AddAsync(entity);
            await _applicationDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _applicationDbContext.Set<T>().Remove(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public Task<bool> ExistsAsync(T entity)
        {
            return _applicationDbContext.Set<T>().AnyAsync(e => e.Id == entity.Id);
        }

        public IAsyncEnumerable<T> GetAllAsync() => _applicationDbContext.Set<T>().ToAsyncEnumerable();

        public async Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _applicationDbContext.Set<T>();
            foreach (Expression<Func<T, object>> includedProperty in includes)
            {
                query = query.Include(includedProperty);
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _applicationDbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
            return result;
        }

        public async Task<T> GetByIdAsync(int id, Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _applicationDbContext.Set<T>();
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
            return await query.SingleOrDefaultAsync();
        }

        public Task UpdateAsync(T entity)
        {
            _applicationDbContext.Entry(entity).State = EntityState.Modified;
            _applicationDbContext.SaveChangesAsync();
            return Task.FromResult(entity);
        }
    }
}

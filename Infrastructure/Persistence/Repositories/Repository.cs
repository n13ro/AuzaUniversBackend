using Domain.Common;
using Domain.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _ctx;
        protected readonly DbSet<T> _dbSet;

        public Repository(AppDbContext ctx)
        {
            _ctx = ctx;
            _dbSet = ctx.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _ctx.SaveChangesAsync();
            return entity;

        }

        public Task DeleteAsync(int id)
        {
            return _dbSet.Where(s => s.Id == id).ExecuteDeleteAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _dbSet.AnyAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FirstAsync(s => s.Id == id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _ctx.SaveChangesAsync();
        }
    }
}

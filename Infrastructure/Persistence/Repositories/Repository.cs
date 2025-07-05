using Domain.Common;
using Domain.Exceptions;
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
            await using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                await _dbSet.AddAsync(entity);
                await _ctx.SaveChangesAsync();
                await transaction.CommitAsync();
                return entity;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new ValidationException($"{ex.Message}, adding error");
            }

        }

        public async Task DeleteAsync(int id)
        {
            await using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                await _dbSet.Where(s => s.Id == id).ExecuteDeleteAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new ValidationException($"{ex.Message}, deletion error");
            }
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
            await using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _dbSet.Update(entity);
                await _ctx.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new ValidationException($"{ex.Message}, update error");
            }
        }
    }
}

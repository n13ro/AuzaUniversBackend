using DataAccess.DTOs.DTOPair;
using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess.Repository.PairRepo
{
    public class PairRepository(AppDbContext ctx) : IPairRepository
    {
        public async Task AddPairRepositoryAsync(DTOPairRepository pair, CancellationToken cancellationToken = default)
        {
            var newPair = new Pair
            {
                Name = pair.Name,
                DateTime = pair.DateTime,
                Auditorium = pair.Auditorium,
            };
            await using var transaction = await ctx.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                await ctx.Pairs.AddAsync(newPair, cancellationToken);
                await ctx.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);

            }catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
            }
        }

        public async Task DeletePairRepositoryAsync(int id, CancellationToken cancellationToken = default)
        {
            await using var transaction = await ctx.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                await ctx.Pairs.Where(s => s.Id == id).ExecuteDeleteAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);

            } catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
            }
        }

        public async Task<IEnumerable<Pair>> GetAllPairRepositoryAsync(CancellationToken cancellationToken = default)
        {
            return await ctx.Pairs.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<Pair> GetByIdPairRepositoryAsync(int id, CancellationToken cancellationToken = default)
        { 
            return await ctx.Pairs.AsNoTracking().FirstAsync(pair => pair.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Pair>> GetByPagePaginationRepositoryAsync(int page, int size, CancellationToken cancellationToken = default)
        {
            return await ctx.Pairs.AsNoTracking()
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync(cancellationToken);
        }

        public async Task UpdatePairRepositoryAsync(DTOPairRepository pair, CancellationToken cancellationToken = default)
        {
            await using var transaction = await ctx.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                await ctx.Pairs.Where(k => k.Id == pair.Id)
                    .ExecuteUpdateAsync(s => s
                        .SetProperty(c => c.Name, pair.Name)
                        .SetProperty(c => c.DateTime, pair.DateTime)
                        .SetProperty(c => c.Auditorium, pair.Auditorium)
                        , cancellationToken);
                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
            }
        }
    }
}

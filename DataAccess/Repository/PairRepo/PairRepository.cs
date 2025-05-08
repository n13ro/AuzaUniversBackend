using DataAccess.DTOs.DTOPair;
using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.PairRepo
{
    public class PairRepository(AppDbContext ctx) : IPairRepository
    {
        public async Task AddPairRepositoryAsync(DTOPairRepository pair, CancellationToken cancellationToken = default)
        {
            await ctx.Pairs.AddAsync(pair, cancellationToken);
            await ctx.SaveChangesAsync(cancellationToken);
        }

        public async Task DeletePairRepositoryAsync(int id, CancellationToken cancellationToken = default)
        {
            await ctx.Pairs.Where(s => s.Id == id).ExecuteDeleteAsync(cancellationToken);
        }

        public async Task<IEnumerable<Pair>> GetAllPairRepositoryAsync(CancellationToken cancellationToken = default)
        {
            return await ctx.Pairs.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task GetByIdPairRepositoryAsync(int id, CancellationToken cancellationToken = default)
        { 
            await ctx.Pairs.AsNoTracking().FirstAsync(pair => pair.Id == id, cancellationToken);
        }

        public async Task UpdatePairRepositoryAsync(DTOPairRepository pair, CancellationToken cancellationToken = default)
        {
            await ctx.Pairs.Where(k => k.Id == pair.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.Name, pair.Name)
                    .SetProperty(c => c.DateTime, pair.DateTime)
                    .SetProperty(c => c.Auditorium, pair.Auditorium)
                    , cancellationToken);
        }
    }
}

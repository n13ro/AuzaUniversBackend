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
        public async Task AddPairRepositoryAsync(Pair pair, CancellationToken cancellationToken = default)
        {
            await ctx.Pairs.AddAsync(pair, cancellationToken);
            await ctx.SaveChangesAsync(cancellationToken);
        }

        public async Task DeletePairRepositoryAsync(int id, CancellationToken cancellationToken = default)
        {
            var onePair = await ctx.Pairs.FirstAsync(pair => pair.Id == id, cancellationToken);
            ctx.Pairs.Remove(onePair);
            await ctx.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Pair>> GetAllPairRepositoryAsync(CancellationToken cancellationToken = default)
        {
            return await ctx.Pairs.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<Pair> GetByIdPairRepositoryAsync(int id, CancellationToken cancellationToken = default)
        {
            var onePair = await ctx.Pairs.FirstAsync(pair => pair.Id == id, cancellationToken);
            return onePair;
        }

        public Task UpdatePairRepositoryAsync(Pair student, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

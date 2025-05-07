using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Ment
{
    internal class MentorRepository(AppDbContext ctx) : IMentorRepository
    {

        public async Task AddMentorRepositoryAsync(Mentor mentor, CancellationToken cancellationToken = default)
        {
            await ctx.Mentors.AddAsync(mentor, cancellationToken);
            await ctx.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteMentorRepositoryAsync(int id, CancellationToken cancellationToken = default)
        {
            //var oneMentor = await ctx.Mentors.FirstAsync(ctx => ctx.Id == id, cancellationToken);
            await ctx.Mentors.Where(k => k.Id == id).ExecuteDeleteAsync(cancellationToken);
            //await ctx.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Mentor>> GetAllMentorRepositoryAsync(CancellationToken cancellationToken = default)
        {
            return await ctx.Mentors.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<Mentor> GetByIdMentorRepositoryAsync(int id, CancellationToken cancellationToken = default)
        {
            var oneMentor = await ctx.Mentors.AsNoTracking().FirstAsync(ctx => ctx.Id == id, cancellationToken);
            return oneMentor;
        }

        public async Task UpdateMentorRepositoryAsync(Mentor mentor, CancellationToken cancellationToken = default)
        {
            await ctx.Mentors.Where(k => k.Id == mentor.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.LastName, mentor.LastName)
                    ,cancellationToken);
        }
    }
}

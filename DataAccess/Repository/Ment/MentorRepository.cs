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
            var oneMentor = await ctx.Mentors.FirstAsync(ctx => ctx.Id == id, cancellationToken);
            ctx.Mentors.Remove(oneMentor);
            await ctx.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Mentor>> GetAllMentorRepositoryAsync(CancellationToken cancellationToken = default)
        {
            return await ctx.Mentors.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<Mentor> GetByIdMentorRepositoryAsync(int id, CancellationToken cancellationToken = default)
        {
            var oneMentor = await ctx.Mentors.FirstAsync(ctx => ctx.Id == id, cancellationToken);
            return oneMentor;
        }

        public Task UpdateMentorRepositoryAsync(Mentor mentor, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

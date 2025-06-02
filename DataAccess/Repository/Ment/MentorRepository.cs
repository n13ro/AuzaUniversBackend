using DataAccess.DTOs.Ment;
using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Repository.Ment
{
    internal class MentorRepository(AppDbContext ctx) : IMentorRepository
    {

        public async Task AddMentorRepositoryAsync(DTOCreateMentorRepository mentor, CancellationToken cancellationToken = default)
        {
            var newMentor = new Mentor
            {
                Name = mentor.Name,
                FirstName = mentor.FirstName,
                LastName = mentor.LastName,
                Email = mentor.Email,
                Phone = mentor.Phone
            };
            await using var transaction = await ctx.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                await ctx.Mentors.AddAsync(newMentor, cancellationToken);
                await ctx.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);

            }catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
            }
        }

        public async Task DeleteMentorRepositoryAsync(int id, CancellationToken cancellationToken = default)
        {
            await using var transaction = await ctx.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                await ctx.Mentors.Where(k => k.Id == id).ExecuteDeleteAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
            } catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
            }
        }

        public async Task<IEnumerable<DTOMentorRepository>> GetAllMentorRepositoryAsync(CancellationToken cancellationToken = default)
        {
            return await ctx.Mentors
                .Select(s => new DTOMentorRepository
                {
                    Id = s.Id,
                    Name = s.Name,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Email = s.Email,
                    Phone = s.Phone
                })
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Mentor> GetByIdMentorRepositoryAsync(int id, CancellationToken cancellationToken = default)
        {
            return await ctx.Mentors.AsNoTracking().FirstAsync(ctx => ctx.Id == id, cancellationToken); ;
        }

        public async Task<IEnumerable<Mentor>> GetByPagePaginationRepositoryAsync(int page, int size, CancellationToken cancellationToken = default)
        {
            return await ctx.Mentors.AsNoTracking()
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync(cancellationToken);
        }

        public async Task UpdateMentorRepositoryAsync(DTOUpdateMentorRepository mentor, CancellationToken cancellationToken = default)
        {
            await using var transaction = await ctx.Database.BeginTransactionAsync(cancellationToken);

            try
            {
                await ctx.Mentors.Where(k => k.Id == mentor.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.Name, mentor.Name)
                    .SetProperty(c => c.FirstName, mentor.FirstName)
                    .SetProperty(c => c.LastName, mentor.LastName)
                    .SetProperty(c => c.Phone, mentor.Phone)
                    , cancellationToken);
                await transaction.CommitAsync(cancellationToken);
            } catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
            }
        }
    }
}

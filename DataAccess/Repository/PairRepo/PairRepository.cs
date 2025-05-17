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
        public async Task AddPairRepositoryAsync(DTOCreatePairRepository pair, CancellationToken cancellationToken = default)
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

        public async Task AssignPairToStudentRepositoryAsync(int studentId, int pairId, CancellationToken cancellationToken = default)
        {
            await using var transaction = await ctx.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var student = await ctx.Students
                    .Include(p => p.MyPair)
                    .FirstAsync(k => k.Id == studentId, cancellationToken);

                var pair = await ctx.Pairs
                    .Include(s => s.Students)
                    .FirstAsync(k => k.Id == pairId, cancellationToken);

                if (student == null || pair == null)
                {
                    throw new Exception("Student or Pair not found");
                }
                if (!student.MyPair.Contains(pair))
                {
                    student.MyPair.Add(pair);
                    await ctx.SaveChangesAsync(cancellationToken);
                }
                if (!pair.Students.Contains(student))
                {
                    pair.Students.Add(student);
                    await ctx.SaveChangesAsync(cancellationToken);
                }

                await transaction.CommitAsync(cancellationToken);


            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
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

        public async Task UpdatePairRepositoryAsync(DTOUpdatePairRepository pair, CancellationToken cancellationToken = default)
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

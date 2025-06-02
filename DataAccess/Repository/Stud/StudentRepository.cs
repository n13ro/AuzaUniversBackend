using DataAccess.DAOs.Stud;
using DataAccess.DTOs.Stud;
using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Repository.Stud
{
    public class StudentRepository(AppDbContext ctx) : IStudentRepository
    {

        public async Task AddStudentRepositoryAsync(DTOCreateStudentRepository student, CancellationToken cancellationToken = default)
        {
            var newStudent = new Student
            {
                Name = student.Name,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                Phone = student.Phone
            };
            await using var transaction = await ctx.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                await ctx.Students.AddAsync(newStudent, cancellationToken);
                await ctx.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
            }
            
        }

        public async Task DeleteStudentRepositoryAsync(int id, CancellationToken cancellationToken = default)
        {
            await using var transaction = await ctx.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                await ctx.Students.Where(s => s.Id == id)
                    .ExecuteDeleteAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
            } catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
            }

        }

        public async Task<IEnumerable<DTOStudentRepository>> GetAllStudentRepositoryAsync(CancellationToken cancellationToken = default)
        {

            return await ctx.Students
                .Select(s => new DTOStudentRepository {
                        Id = s.Id,
                        Name = s.Name,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Email = s.Email,
                        Phone = s.Phone
                        }
                    )
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Student> GetByIdStudentRepositoryAsync(int id, CancellationToken cancellationToken = default)
        {
            return await ctx.Students.AsNoTracking()
                .FirstAsync(ctx => ctx.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Student>> GetByPagePaginationRepositoryAsync(int page, int size, CancellationToken cancellationToken = default)
        {
            return await ctx.Students.AsNoTracking()
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync(cancellationToken);
        }

        public async Task UpdateStudentRepositoryAsync(DTOUpdateStudentRepository student, CancellationToken cancellationToken = default)
        {
            await using var transaction = await ctx.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                await ctx.Students
                    .Where(k => k.Id == student.Id)
                    .ExecuteUpdateAsync(s =>s
                        .SetProperty(c => c.LastName, student.LastName)
                        .SetProperty(c => c.FirstName, student.FirstName)
                        .SetProperty(c => c.Email, student.Email)
                        .SetProperty(c => c.Phone, student.Phone)
                        , cancellationToken
                    );
                await transaction.CommitAsync(cancellationToken);
            } catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
            }
        }

    }
}

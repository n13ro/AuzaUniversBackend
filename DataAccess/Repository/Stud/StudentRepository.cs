using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Stud
{
    public class StudentRepository(AppDbContext ctx) : IStudentRepository
    {

        public async Task AddStudentRepositoryAsync(Student student, CancellationToken cancellationToken = default)
        {
            await ctx.Students.AddAsync(student, cancellationToken);
            await ctx.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteStudentRepositoryAsync(int id, CancellationToken cancellationToken = default)
        {
           //var OneStud =  await ctx.Students.FirstAsync(ctx => ctx.Id == id, cancellationToken);
           await ctx.Students.Where(s => s.Id == id).ExecuteDeleteAsync(cancellationToken);
           //await ctx.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Student>> GetAllStudentRepositoryAsync(CancellationToken cancellationToken = default)
        {
            return await ctx.Students.AsNoTracking().ToListAsync(cancellationToken);
        
        }

        public async Task<Student> GetByIdStudentRepositoryAsync(int id, CancellationToken cancellationToken = default)
        {
            var oneStud = await ctx.Students.AsNoTracking().FirstAsync(ctx=>ctx.Id == id, cancellationToken);
            return oneStud;
        }

        public async Task UpdateStudentRepositoryAsync(Student student, CancellationToken cancellationToken = default)
        {
            await ctx.Students
                .Where(k => k.Id == student.Id)
                .ExecuteUpdateAsync(s =>s
                    .SetProperty(c => c.LastName, student.LastName)
                    .SetProperty(c => c.FirstName, student.FirstName)
                    
                    , cancellationToken
                );

        }
    }
}

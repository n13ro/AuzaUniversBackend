using DataAccess.DAOs.Stud;
using DataAccess.DTOs.Stud;
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

        public async Task AddStudentRepositoryAsync(DTOStudentRepository student, CancellationToken cancellationToken = default)
        {
            await ctx.Students.AddAsync(student, cancellationToken);
            await ctx.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteStudentRepositoryAsync(int id, CancellationToken cancellationToken = default)
        {
           await ctx.Students.Where(s => s.Id == id)
                .ExecuteDeleteAsync(cancellationToken);
        }

        public async Task<IEnumerable<Student>> GetAllStudentRepositoryAsync(CancellationToken cancellationToken = default)
        {
            return await ctx.Students.AsNoTracking()
                .ToListAsync(cancellationToken);
        
        }

        public async Task GetByIdStudentRepositoryAsync(int id, CancellationToken cancellationToken = default)
        {
            await ctx.Students.AsNoTracking()
                .FirstAsync(ctx => ctx.Id == id, cancellationToken);
        }

        public async Task UpdateStudentRepositoryAsync(DTOStudentRepository student, CancellationToken cancellationToken = default)
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

        }
    }
}

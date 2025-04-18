using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Stud
{
    internal class StudentRepository(AppDbContext ctx) : IStudentRepository
    {

        public async Task AddAsync(Student student, CancellationToken cancellationToken = default)
        {
            await ctx.Students.AddAsync(student, cancellationToken);
            await ctx.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
           var OneStud =  await ctx.Students.FirstAsync(c => c.Id == id, cancellationToken);
           ctx.Students.Remove(OneStud);
           await ctx.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Student>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await ctx.Students.ToListAsync(cancellationToken);
        
        }

        public async Task<Student> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var oneStud = await ctx.Students.FirstAsync(c=>c.Id == id, cancellationToken);
            return oneStud;
        }

        public Task UpdateAsync(Student student, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

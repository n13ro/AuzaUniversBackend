using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence.Repositories.StudentRepo
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<IEnumerable<Student>> GetStudentsByGroupAsync(int groupId);
        Task<Student?> GetStudentWithGroupAsync(int id);
        Task<IEnumerable<Student>> GetStudentsByLevelAsync(int level);
    }
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext ctx) : base(ctx) { }

        public async Task<IEnumerable<Student>> GetStudentsByGroupAsync(int groupId)
        {
            return await _dbSet.Where(s => s.Id == groupId).ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudentsByLevelAsync(int level)
        {
            return await _dbSet.Where(s => s.Level == level).ToListAsync();
        }

        public async Task<Student?> GetStudentWithGroupAsync(int id)
        {
            return await _dbSet.Where(s => s.Id == id)
                .Include(s => s.MyGroup)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}

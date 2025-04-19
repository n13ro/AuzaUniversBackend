using DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Stud
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentRepositoryAsync(CancellationToken cancellationToken = default);
        Task<Student> GetByIdStudentRepositoryAsync(int id, CancellationToken cancellationToken = default);
        Task AddStudentRepositoryAsync(Student student, CancellationToken cancellationToken = default);
        Task UpdateStudentRepositoryAsync(Student student, CancellationToken cancellationToken = default);
        Task DeleteStudentRepositoryAsync(int id, CancellationToken cancellationToken = default);

    }
}

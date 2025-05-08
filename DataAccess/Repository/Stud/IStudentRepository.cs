using DataAccess.DAOs.Stud;
using DataAccess.DTOs.Stud;
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
        Task GetByIdStudentRepositoryAsync(int id, CancellationToken cancellationToken = default);
        Task AddStudentRepositoryAsync(DTOStudentRepository student, CancellationToken cancellationToken = default);
        Task UpdateStudentRepositoryAsync(DTOStudentRepository student, CancellationToken cancellationToken = default);
        Task DeleteStudentRepositoryAsync(int id, CancellationToken cancellationToken = default);

    }
}

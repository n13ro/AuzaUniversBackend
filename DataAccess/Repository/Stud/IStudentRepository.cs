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
        Task<IEnumerable<DTOStudentRepository>> GetAllStudentRepositoryAsync(CancellationToken cancellationToken = default);
        Task<Student> GetByIdStudentRepositoryAsync(int id, CancellationToken cancellationToken = default);
        Task AddStudentRepositoryAsync(DTOCreateStudentRepository student, CancellationToken cancellationToken = default);
        Task UpdateStudentRepositoryAsync(DTOUpdateStudentRepository student, CancellationToken cancellationToken = default);
        Task DeleteStudentRepositoryAsync(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<Student>> GetByPagePaginationRepositoryAsync(int page, int size, CancellationToken cancellationToken = default);

    }
}

using BusinessLogic.DTOs.Stud;
using DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Stud
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentServiceAsync(CancellationToken cancellationToken = default);
        Task<Student> GetByIdStudentServiceAsync(int id,CancellationToken cancellationToken = default);

        Task AddStudentServiceAsync(DTOCreateStudentService student, CancellationToken cancellationToken = default);

        Task UpdateStudentServiceAsync(DTOUpdateStudentService student, CancellationToken cancellationToken = default);

        Task DeleteStudentServiceAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Student>> GetByPagePaginationServiceAsync(int page, int size, CancellationToken cancellationToken = default);
    }
}

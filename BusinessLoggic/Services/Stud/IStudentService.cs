using BusinessLogic.DTOs.Stud;
using DataAccess.DTOs.Stud;
using DataAccess.Entites;


namespace BusinessLogic.Services.Stud
{
    public interface IStudentService
    {
        Task<IEnumerable<DTOStudentRepository>> GetAllStudentServiceAsync(CancellationToken cancellationToken = default);
        Task<Student> GetByIdStudentServiceAsync(int id,CancellationToken cancellationToken = default);

        Task AddStudentServiceAsync(DTOCreateStudentService student, CancellationToken cancellationToken = default);

        Task UpdateStudentServiceAsync(DTOUpdateStudentService student, CancellationToken cancellationToken = default);

        Task DeleteStudentServiceAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Student>> GetByPagePaginationServiceAsync(int page, int size, CancellationToken cancellationToken = default);
    }
}

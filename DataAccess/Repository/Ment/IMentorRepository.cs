using DataAccess.DTOs.Ment;
using DataAccess.Entites;


namespace DataAccess.Repository.Ment
{
    public interface IMentorRepository
    {
        Task<IEnumerable<DTOMentorRepository>> GetAllMentorRepositoryAsync(CancellationToken cancellationToken = default);
        Task<Mentor> GetByIdMentorRepositoryAsync(int id, CancellationToken cancellationToken = default);
        Task AddMentorRepositoryAsync(DTOCreateMentorRepository mentor, CancellationToken cancellationToken = default);
        Task UpdateMentorRepositoryAsync(DTOUpdateMentorRepository mentor,CancellationToken cancellationToken = default);
        Task DeleteMentorRepositoryAsync(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<Mentor>> GetByPagePaginationRepositoryAsync(int page, int size, CancellationToken cancellationToken = default);

    }
}

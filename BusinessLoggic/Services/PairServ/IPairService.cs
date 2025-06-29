using BusinessLogic.DTOs.DTOPair;
using DataAccess.Entites;


namespace BusinessLogic.Services.PairService
{
    public interface IPairService
    {
        Task<IEnumerable<Pair>> GetAllPairServiceAsync(CancellationToken cancellationToken = default);
        Task<Pair> GetByIdPairServiceAsync(int id, CancellationToken cancellationToken = default);
        Task AddPairServiceAsync(DTOCreatePairService pair, CancellationToken cancellationToken = default);

        Task UpdatePairServiceAsync(DTOUpdatePairService pair, CancellationToken cancellationToken = default);

        Task DeletePairServiceAsync(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<Pair>> GetByPagePaginationServiceAsync(int page, int size, CancellationToken cancellationToken = default);

        Task AssignPairToStudentServiceAsync(int studentId, int pairId, CancellationToken cancellationToken = default);

        Task AssignPairToMentorServiceAsync(int mentorId, int pairId, CancellationToken cancellationToken = default);
    }
}

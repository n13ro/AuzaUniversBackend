using BusinessLogic.DTOs.DTOPair;
using DataAccess.Entites;


namespace BusinessLogic.Services.PairService
{
    public interface IPairService
    {
        Task<IEnumerable<Pair>> GetAllPairServiceAsync(CancellationToken cancellationToken = default);
        Task<Pair> GetByIdPairServiceAsync(int id, CancellationToken cancellationToken = default);
        Task AddPairServiceAsync(DTOPairService pair, CancellationToken cancellationToken = default);

        Task UpdatePairServiceAsync(DTOPairService pair, CancellationToken cancellationToken = default);

        Task DeletePairServiceAsync(int id, CancellationToken cancellationToken = default);
    }
}

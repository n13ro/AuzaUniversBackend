using DataAccess.Entites;


namespace BusinessLogic.Services.PairService
{
    public interface IPairService
    {
        Task<IEnumerable<Pair>> GetAllPairServiceAsync(CancellationToken cancellationToken = default);
        Task GetByIdPairServiceAsync(int id, CancellationToken cancellationToken = default);
        Task AddPairServiceAsync(string Name, CancellationToken cancellationToken = default);

        Task UpdatePairServiceAsync(Pair pair, CancellationToken cancellationToken = default);

        Task DeletePairServiceAsync(int id, CancellationToken cancellationToken = default);
    }
}

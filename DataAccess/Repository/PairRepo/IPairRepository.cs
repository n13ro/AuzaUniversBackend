using DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.PairRepo
{
    public interface IPairRepository
    {
        Task<IEnumerable<Pair>> GetAllPairRepositoryAsync(CancellationToken cancellationToken = default);
        Task<Pair> GetByIdPairRepositoryAsync(int id, CancellationToken cancellationToken = default);
        Task AddPairRepositoryAsync(Pair student, CancellationToken cancellationToken = default);
        Task UpdatePairRepositoryAsync(Pair student, CancellationToken cancellationToken = default);
        Task DeletePairRepositoryAsync(int id, CancellationToken cancellationToken = default);
    }
}

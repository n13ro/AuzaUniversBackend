using DataAccess.DTOs.DTOPair;
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
        Task AddPairRepositoryAsync(DTOCreatePairRepository pair, CancellationToken cancellationToken = default);
        Task UpdatePairRepositoryAsync(DTOUpdatePairRepository pair, CancellationToken cancellationToken = default);
        Task DeletePairRepositoryAsync(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<Pair>> GetByPagePaginationRepositoryAsync(int page, int size, CancellationToken cancellationToken = default);

        Task AssignPairToStudentRepositoryAsync(int studentId, int pairId, CancellationToken cancellationToken = default);
    }
}

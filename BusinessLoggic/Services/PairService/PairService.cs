using DataAccess.Entites;
using DataAccess.Repository.PairRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.PairService
{
    internal class PairService(IPairRepository pairRepository) : IPairService
    {
        public async Task AddPairServiceAsync(string Name, DateTime DateTime, CancellationToken cancellationToken = default)
        {
            var newPair = new Pair 
            {
                Name = Name,
                DateTime = DateTime,
            };
            await pairRepository.AddPairRepositoryAsync(newPair, cancellationToken);
        }

        public async Task DeletePairServiceAsync(int id, CancellationToken cancellationToken = default)
        {
            await pairRepository.DeletePairRepositoryAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<Pair>> GetAllPairServiceAsync(CancellationToken cancellationToken = default)
        {
            var pairs = await pairRepository.GetAllPairRepositoryAsync(cancellationToken);
            return pairs;
        }

        public async Task GetByIdPairServiceAsync(int id, CancellationToken cancellationToken = default)
        {
            await pairRepository.GetByIdPairRepositoryAsync(id, cancellationToken);
        }

        public Task UpdatePairServiceAsync(Pair pair, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

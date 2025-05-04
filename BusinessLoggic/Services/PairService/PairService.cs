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
        public Task AddPairServiceAsync(string Name, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeletePairServiceAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pair>> GetAllPairServiceAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task GetByIdPairServiceAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePairServiceAsync(Pair pair, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

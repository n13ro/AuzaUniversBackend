using DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.GroupRepo
{
    public class GroupRepository(AppDbContext ctx) : IGroupRepository
    {
        public Task AddGroupRepositoryAsync(Group group, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGroupRepositoryAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Group>> GetAllGroupRepositoryAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Group> GetByIdGroupRepositoryAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateGroupRepositoryAsync(Group student, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

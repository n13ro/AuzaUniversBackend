using DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.GroupRepo
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> GetAllGroupRepositoryAsync(CancellationToken cancellationToken = default);
        Task<Group> GetByIdGroupRepositoryAsync(int id, CancellationToken cancellationToken = default);
        Task AddGroupRepositoryAsync(Group student, CancellationToken cancellationToken = default);
        Task UpdateGroupRepositoryAsync(Group group, CancellationToken cancellationToken = default);
        Task DeleteGroupRepositoryAsync(int id, CancellationToken cancellationToken = default);
    }
}

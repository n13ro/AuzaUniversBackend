using DataAccess.DTOs.Ment;
using DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Ment
{
    public interface IMentorRepository
    {
        Task<IEnumerable<Mentor>> GetAllMentorRepositoryAsync(CancellationToken cancellationToken = default);
        Task GetByIdMentorRepositoryAsync(int id, CancellationToken cancellationToken = default);
        Task AddMentorRepositoryAsync(DTOMentorRepository mentor, CancellationToken cancellationToken = default);
        Task UpdateMentorRepositoryAsync(DTOMentorRepository mentor,CancellationToken cancellationToken = default);
        Task DeleteMentorRepositoryAsync(int id, CancellationToken cancellationToken = default);
    }
}

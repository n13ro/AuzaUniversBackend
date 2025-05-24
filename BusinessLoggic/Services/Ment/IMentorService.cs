using BusinessLogic.DTOs.Ment;
using DataAccess.DTOs.Ment;
using DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Ment
{
    public interface IMentorService
    {
        Task<IEnumerable<DTOMentorRepository>> GetAllMentorServiceAsync(CancellationToken cancellationToken = default);
        Task<Mentor> GetByIdMentorServiceAsync(int id, CancellationToken cancellationToken = default);
        Task AddMentorServiceAsync(DTOCreateMentorService mentor, CancellationToken cancellationToken = default);

        Task UpdateMentorServiceAsync(DTOUpdateMentorService mentor, CancellationToken cancellationToken = default);

        Task DeleteMentorServiceAsync(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<Mentor>> GetByPagePaginationServiceAsync(int page, int size, CancellationToken cancellationToken = default);

    }
}

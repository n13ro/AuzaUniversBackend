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
        Task<IEnumerable<Student>> GetAllMentorServiceAsync(CancellationToken cancellationToken = default);
        Task GetByIdMentorServiceAsync(int id, CancellationToken cancellationToken = default);
        Task AddMentorServiceAsync(string Name, string FirstName, string LastName, string Email, string Phone, CancellationToken cancellationToken = default);

        Task UpdateMentorServiceAsync(Mentor mentor, CancellationToken cancellationToken = default);

        Task DeleteMentorServiceAsync(int id, CancellationToken cancellationToken = default);
    }
}

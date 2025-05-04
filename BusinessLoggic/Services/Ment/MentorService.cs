using DataAccess.Entites;
using DataAccess.Repository.Ment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Ment
{
    internal class MentorService(IMentorRepository mentorRepository) : IMentorService
    {
        public Task AddMentorServiceAsync(string Name, string FirstName, string LastName, string Email, string Phone, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMentorServiceAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAllMentorServiceAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task GetByIdMentorServiceAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMentorServiceAsync(Mentor mentor, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

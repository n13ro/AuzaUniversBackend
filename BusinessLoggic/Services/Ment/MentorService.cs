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
        public async Task AddMentorServiceAsync(string Name, string FirstName, string LastName, string Email, string Phone, CancellationToken cancellationToken = default)
        {
            var newMentor = new Mentor 
            {
                Name = Name,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Phone = Phone,
            };
            await mentorRepository.AddMentorRepositoryAsync(newMentor, cancellationToken);
            //return 
        }

        public async Task DeleteMentorServiceAsync(int id, CancellationToken cancellationToken = default)
        {
            await mentorRepository.DeleteMentorRepositoryAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<Mentor>> GetAllMentorServiceAsync(CancellationToken cancellationToken = default)
        {
            var mentors = await mentorRepository.GetAllMentorRepositoryAsync(cancellationToken);
            return mentors;
        }

        public async Task GetByIdMentorServiceAsync(int id, CancellationToken cancellationToken = default)
        {
            await mentorRepository.GetByIdMentorRepositoryAsync(id, cancellationToken);
        }

        public Task UpdateMentorServiceAsync(Mentor mentor, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

    }
}

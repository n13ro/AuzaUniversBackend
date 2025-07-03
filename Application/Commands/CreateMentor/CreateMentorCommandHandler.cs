using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.CreateMentor
{
    public class CreateMentorCommandHandler : IRequestHandler<CreateMentorCommand, int>
    {
        private readonly IRepository<Mentor> _repositoryMentor;

        public CreateMentorCommandHandler(IRepository<Mentor> repositoryMentor)
        {
            _repositoryMentor = repositoryMentor;
        }

        public async Task<int> Handle(CreateMentorCommand request, CancellationToken cancellationToken)
        {
            var mentor = new Mentor(
                request.Name, 
                request.FirstName, 
                request.LastName, 
                request.Email, 
                request.Phone
                );

            await _repositoryMentor.AddAsync(mentor);

            return mentor.Id;
        }
    }
}

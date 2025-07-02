using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.CreatePair
{
    public class CreatePairCommandHandler : IRequestHandler<CreatePairCommand, int>
    {
        private readonly IRepository<Pair> _pairRepository;
        private readonly IRepository<Group> _groupRepository;

        public CreatePairCommandHandler(
            IRepository<Pair> pairRepository,
            IRepository<Group> groupRepository
            )
        {
            _pairRepository = pairRepository;
            _groupRepository = groupRepository;
        }

        public async Task<int> Handle(CreatePairCommand request, CancellationToken cancellationToken)
        {
            var group = await _groupRepository.GetByIdAsync(request.GroupId);
            if (group == null)
            {
                throw new Exception("Группа не найдена");
            }

            var pair = new Pair(
                request.Name,
                request.StartTime,
                request.EndTime,
                request.Auditorium
            );

            pair.EnrollGroup( group );

            var createdPair = await _pairRepository.AddAsync(pair);
            return createdPair.Id;

        }
    }
}

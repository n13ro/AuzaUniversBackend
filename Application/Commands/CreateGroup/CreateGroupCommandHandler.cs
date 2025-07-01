using Domain.Entities;
using Domain.Repositories;
using MediatR;


namespace Application.Commands.CreateGroup
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, int>
    {
        private readonly IRepository<Group> _groupRepository;

        public CreateGroupCommandHandler (IRepository<Group> groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public async Task<int> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = new Group(request.Name);
            await _groupRepository.AddAsync(group);
            return group.Id;
        }
    }
}

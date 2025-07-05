using Application.DTOs;
using Domain.Entities;
using Domain.Repositories;
using MediatR;


namespace Application.Queries.GetGroups
{
    public class GetGroupQueryHandler : IRequestHandler<GetGroupsQuery, PaginationResponse<GroupRequest>>
    {
        private readonly IRepository<Group> _groupRepository;

        public GetGroupQueryHandler(IRepository<Group> groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<PaginationResponse<GroupRequest>> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
        {
            var groups = await _groupRepository.GetAllAsync(request.Page, request.Take);

            return new PaginationResponse<GroupRequest>
            {
                Items = groups.Select(s => new GroupRequest
                {
                    Name = s.Name,
                }),
                Page = request.Page,
                PageSize = request.PageSize,
            };
        }
    }
}

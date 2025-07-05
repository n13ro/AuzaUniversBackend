using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetGroups
{
    public record GetGroupsQuery : IRequest<IEnumerable<GroupRequest>>
    {
        public int Page { get; init; } = 1;
        public int Size { get; init; } = 20;
    }
}

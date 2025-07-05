using Application.Commands.CreateGroup;
using Application.DTOs;
using Application.Queries.GetGroups;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace UniversSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GroupsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupRequest>>> GetGroups([FromQuery] int page = 1, [FromQuery] int size = 20)
        {
            var query = new GetGroupsQuery { Page = page, PageSize = size };
            var groups = await _mediator.Send(query);

            return Ok(groups);
        }

        [HttpPost]
        public async Task<ActionResult> CreateGroup([FromBody] CreateGroupCommand command)
        {
            var groupId = await _mediator.Send(command);
            return Ok(groupId);
        }
    }
}

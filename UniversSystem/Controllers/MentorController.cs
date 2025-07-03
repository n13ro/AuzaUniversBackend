using Application.Commands.CreateMentor;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniversSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MentorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateMentor(CreateMentorCommand command)
        {
            var mentorId = await _mediator.Send(command);
            return Ok(mentorId);
        }
    }
}

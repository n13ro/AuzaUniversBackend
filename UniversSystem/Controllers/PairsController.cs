using Application.Commands.CreatePair;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniversSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PairsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PairsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreatePair(CreatePairCommand command)
        {

            var pairId = await _mediator.Send(command);
            return Ok(pairId);
        }
    }
}

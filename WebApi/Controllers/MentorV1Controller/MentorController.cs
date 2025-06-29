using BusinessLogic.DTOs.Ment;
using BusinessLogic.Features.MentR.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.MentV1Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MentorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MentorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var mentors = await _mediator.Send(new GetAllMentorsQuery(), cancellationToken);
                return Ok(new {success = true, data = mentors});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
        {

            var oneMentor = await _mediator.Send(new GetByIdMentorQuery(id), cancellationToken);
            if (oneMentor == null)
            {
                return NotFound(new { success = false, message = "Mentor not found" });
            }
            return Ok(new {success = true, data = oneMentor});

        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(DTOCreateMentorService DTOMentorService, CancellationToken cancellationToken)
        {
            try
            {
                await _mediator.Send(new AddMentorCommand(DTOMentorService), cancellationToken);
                return Ok(new { success = true, data = "Mentor is created" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(DTOUpdateMentorService DTOMentorService, CancellationToken cancellationToken)
        {
            try
            {
                await _mediator.Send(new UpdateMentorCommand(DTOMentorService), cancellationToken);
                return Ok(new { success = true, data = "Mentor updated" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                await _mediator.Send(new DeleteMentorCommand(id), cancellationToken);
                return Ok(new { success = true, data = "Student deleted" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetPagination")]
        public async Task<IActionResult> GetPagination(int page, int size, CancellationToken cancellationToken)
        {
            var mentors = await _mediator.Send(new GetByPagePaginationMentorQuery(page, size), cancellationToken);
            return Ok(new { success = true, data = mentors });
        }
    }
}

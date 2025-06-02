using BusinessLogic.DTOs.Ment;
using BusinessLogic.Services.Ment;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.MentV1Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MentorController(IMentorService mentorService) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var mentors = await mentorService.GetAllMentorServiceAsync(cancellationToken);
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

            var oneMentor = await mentorService.GetByIdMentorServiceAsync(id, cancellationToken);
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
                await mentorService.AddMentorServiceAsync(DTOMentorService, cancellationToken);
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
                await mentorService.UpdateMentorServiceAsync(DTOMentorService, cancellationToken);
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
                await mentorService.DeleteMentorServiceAsync(id, cancellationToken);
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
            var mentors = await mentorService.GetByPagePaginationServiceAsync(page, size, cancellationToken);
            return Ok(new { success = true, data = mentors });
        }
    }
}

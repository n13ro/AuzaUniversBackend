using BusinessLogic.Services.Ment;
using BusinessLogic.Services.Stud;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.MentV1Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MentorController(IMentorService mentorService) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task GetAll(CancellationToken cancellationToken)
        {
            await mentorService.GetAllMentorServiceAsync(cancellationToken);
        }
        [HttpGet("GetById/{id}")]
        public async Task GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            await mentorService.GetByIdMentorServiceAsync(id, cancellationToken);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(string Name, string FirstName, string LastName, string Email, string Phone, CancellationToken cancellationToken)
        {
            await mentorService.AddMentorServiceAsync(Name, FirstName, LastName, Email, Phone, cancellationToken);
            return Ok(new { mess = "Mentor is created" });
        }
        //[HttpPut("Update")]
        //public async Task UpdateAsync(Mentor mentor, CancellationToken cancellationToken)
        //{
        //    await mentorService.UpdateAsync();
        //}
        [HttpDelete("Delete/{id}")]
        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await mentorService.DeleteMentorServiceAsync(id, cancellationToken);
        }
    }
}

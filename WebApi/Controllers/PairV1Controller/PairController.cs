using BusinessLogic.Services.Ment;
using BusinessLogic.Services.PairService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.PairV1Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PairController(IPairService pairService) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task GetAll(CancellationToken cancellationToken)
        {
            await pairService.GetAllPairServiceAsync(cancellationToken);
        }
        [HttpGet("GetById/{id}")]
        public async Task GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            await pairService.GetByIdPairServiceAsync(id, cancellationToken);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(string Name, CancellationToken cancellationToken)
        {
            await pairService.AddPairServiceAsync(Name, cancellationToken);
            return Ok(new { mess = "Pair is created" });
        }
        //[HttpPut("Update")]
        //public async Task UpdateAsync(Pair pair, CancellationToken cancellationToken)
        //{
        //    await pairService.UpdateAsync();
        //}
        [HttpDelete("Delete/{id}")]
        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await pairService.DeletePairServiceAsync(id, cancellationToken);
        }
    }
}

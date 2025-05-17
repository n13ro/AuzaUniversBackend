using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Services;

namespace WebApi.Controllers.RabbitMQController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMQController : ControllerBase
    {
        private readonly IRabbitMQService _rabbitMQService;

        public RabbitMQController(IRabbitMQService rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] string msg)
        {
            await _rabbitMQService.PublishMessage(msg, "test-queue");
            return Ok(new { message = "Message sent successfully!" });
        }
        [HttpPost("subs")]
        public async Task<IActionResult> Subscribe()
        {
            await _rabbitMQService.Subscribe("test-queue", async (msg) =>
            {
                Ok(new { message = $"Получено сообщение: {msg}" });
                await Task.CompletedTask;

            });
            return Ok(new { message = $"Subscribed to queue!" });
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Services;
using System.Text.Json;

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
        [HttpPost("subscribe/student/{studentId}")]
        public async Task<IActionResult> SubscribeToStudentNotifications(int studentId)
        {
            var queueName = $"student_notifications_{studentId}";
            await _rabbitMQService.Subscribe(queueName, async(msg) =>
            {
                Console.WriteLine(msg);
                await Task.CompletedTask;
            });
            return Ok(new { message = $"Подписка на уведомления студента {studentId} активирована" });
        }
        [HttpPost("unsubscribe/student/{studentId}")]
        public async Task<IActionResult> UnsubscribeFromStudentNotifications(int studentId)
        {
            var queueName = $"student_notifications_{studentId}";
            await _rabbitMQService.Unsubscribe(queueName);
            return Ok(new { message = $"Отписка от уведомлений студента {studentId} выполнена" });
        }
        [HttpPost("notify/student/{studentId}")]
        public async Task<IActionResult> NotifyStudent(int studentId, [FromBody] object message)
        {
            var queueName = $"student_notifications_{studentId}";
            await _rabbitMQService.PublishMessage(JsonSerializer.Serialize(message), queueName);
            return Ok(new { message = $"Уведомление для студента {studentId} отправлено" });
        }

        //[HttpPost("send")]
        //public async Task<IActionResult> SendMessage([FromBody] string msg)
        //{
        //    await _rabbitMQService.PublishMessage(msg, "test-queue");
        //    return Ok(new { message = "Message sent successfully!" });
        //}

        //[HttpPost("subs")]
        //public async Task<IActionResult> Subscribe()
        //{
        //    await _rabbitMQService.Subscribe("test-queue", async (msg) =>
        //    {
        //        Ok(new { message = $"Получено сообщение: {msg}" });
        //        await Task.CompletedTask;

        //    });
        //    return Ok(new { message = $"Subscribed to queue!" });
        //}
        //[HttpPost("unsub")]
        //public async Task<IActionResult> Unsubscribe()
        //{
        //    await _rabbitMQService.Unsubscribe("test-queue");
        //    return Ok(new { message = $"Unsubscribed to queue!" });
        //}

    }
}

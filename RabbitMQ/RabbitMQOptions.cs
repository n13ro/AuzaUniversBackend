
namespace RabbitMQ
{
    public class RabbitMQOptions
    {
        public string HostName { get; set; } = "localhost";
        public string UserName { get; set; } = "rmuser";
        public string Password { get; set; } = "rmpassword";
        public int Port { get; set; } = 5672;
    }
}
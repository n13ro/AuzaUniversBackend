using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Services
{
    public interface IRabbitMQService
    {
        Task PublishMessage(string msg, string key);
        Task Subscribe(string queueName, Func<string, Task> handler);
        void Dispose();
    }
}

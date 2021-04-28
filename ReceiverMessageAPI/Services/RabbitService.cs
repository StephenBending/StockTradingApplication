using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiverMessageAPI.Services
{
    public class RabbitService : IRabbitService
    {

        public string CollectMessage(string queueName)
        {
            var receivedMessage = string.Empty;
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "stock", durable: false, exclusive: false, autoDelete: false, arguments: null);
                // below is how to consume the message
                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    // WHY USE SPAN?? because rabbitMQ did not update whn they updated the whole thing
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine("[x] Recieved {0}", message);
                    //
                    receivedMessage = message;
                };
                channel.BasicConsume(queue: "stock", autoAck: true, consumer: consumer);


            }
            return receivedMessage;
        }
    }
}

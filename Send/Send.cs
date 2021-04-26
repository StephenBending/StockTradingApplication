using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Send
{
    class Send
    {
        static void Main(string[] args)
        {
            // Test Data
            Stock stock = new Stock
            {
                Id = 1,
                Name = "Google",
                Value = 1234
            };

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: "stock",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            string message = JsonConvert.SerializeObject(stock);
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(
                exchange: "",
                routingKey: "stock",
                basicProperties: null,
                body: body);

            Console.WriteLine("Sender sent {0}", message);
            Console.ReadLine();
        }
    }
}

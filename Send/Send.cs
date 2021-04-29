using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Send
{
    class Send
    {
        private readonly ConnectionFactory _factory;

        public Send(ConnectionFactory factory)
        {
            _factory = factory;
        }

        public void setupSend()
        {
            // Test Data
            Stock stock = new Stock
            {
                Id = 1,
                Name = "Google",
                Value = 1234
            };

            using var connection = _factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: "stock",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            /*
            string message = JsonConvert.SerializeObject(stock);
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(
                exchange: "",
                routingKey: "stock",
                basicProperties: null,
                body: body);

            Console.WriteLine("Sender sent {0}", message);
            Console.ReadLine();
            */
        }

        public void send(string message)
        {
            using var connection = _factory.CreateConnection();
            using var channel = connection.CreateModel();

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(
                exchange: "",
                routingKey: "stock",
                basicProperties: null,
                body: body);
        }
    }
}

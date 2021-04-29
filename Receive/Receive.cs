using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections;
using System.Text;

namespace Receive
{
    class Receive
    {
        public ArrayList receiveMessages()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var messageList = new ArrayList();
            
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();


            channel.QueueDeclare(
                queue: "stock",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                //Console.WriteLine("Receiver received {0}", message);
                messageList.Add(message);
            };

            channel.BasicConsume(
                queue: "stock",
                autoAck: true,
                consumer: consumer);

            //Console.ReadLine();
            return messageList;
        }
    }
}

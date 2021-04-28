using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenderMessageAPI.Services
{
    public class DummyRabbitService : IRabbitService
    {
        public void publish(string messageJson, string queueName)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SenderMessageAPI.Services
{
    public interface IRabbitService
    {
        public void publish(string messageJson, string queueName);
    }
}

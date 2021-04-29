using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceiverMessageAPI.Services
{
    public interface IRabbitService
    {
        public string CollectMessage(string queueName);

    }
}

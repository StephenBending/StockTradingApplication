using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReceiverMessageAPI.Models;

namespace ReceiverMessageAPI.Services
{
    public interface IMessageService
    {
        public string ReceivedMessage();
        public Task<string> AddToDb();
        

    }
}

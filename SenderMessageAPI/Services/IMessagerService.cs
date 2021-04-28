using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SenderMessageAPI.Models;

namespace SenderMessageAPI.Services
{
    public interface IMessagerService
    {
        public void sendMessage(Message msg);
        public void updateDb(int id, string name, int value);
    }
}

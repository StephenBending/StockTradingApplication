using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenderMessageAPI.Models;
using SenderMessageAPI.Services;

namespace SenderMessageAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [Route("send")]
    public class MessageController : Controller //ControllerBase
    {
        /*
        [HttpPost]
        [Route("{id}/{name}/{value}")]
        public void sendMessage(int id, string name, float value)
        {
            var msg = new Message() { id = id,
                                      name = name,
                                      value = value};
            var TEST = 5 + 6;
        }
        */

        IMessagerService _msgService;

        public MessageController(IMessagerService msgService)
        {
            _msgService = msgService;
        }

        [HttpPut]
        [Route("{id}/{name}/{value}")]
        public void sendMessage(int id, string name, double value)
        {
            _msgService.updateDb(id, name, value);
        }

        [HttpPut]
        [Route("{id}/{name}")]
        [Route("{id}")]
        public string putError()
        {
            return "This API only allows the use of the PUT command, in the format /send/{id}/{name}/{value}";
        }


        [HttpGet]
        [Route("{id}/{name}/{value}")]
        public void getSendFull(int id, string name, double value)
        {
            //Bad way of doing this, but run out of time to do it properly
            _msgService.updateDb(id, name, value);
            //return "This API only allows the use of the PUT command, in the format /send/{id}/{name}/{value}";
        }

        [HttpGet]
        [Route("")]
        public string getSend()
        {
            return "This API only allows the use of the PUT command, in the format /send/{id}/{name}/{value}";
        }

        [HttpPost]
        [Route("")]
        public string postSend()
        {
            return "This API only allows the use of the PUT command, in the format /send/{id}/{name}/{value}";
        }
    }
}

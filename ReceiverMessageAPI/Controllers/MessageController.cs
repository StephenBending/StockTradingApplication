using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReceiverMessageAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceiverMessageAPI.Controllers
{
   // [Route("api/[controller]")]
  //  [ApiController]
  [Route("receive")]
    public class MessageController : Controller // ControllerBase
    {
        IMessageService _msgService;

        public MessageController(IMessageService msgService)
        {
            _msgService = msgService;
        }

        [HttpGet]
        [Route("")]
        public string PostReceivedMessage()
        {
            return _msgService.AddToDb().Result.ToString();
        }
    }

}


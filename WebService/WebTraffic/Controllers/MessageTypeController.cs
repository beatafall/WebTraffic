using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService;
using WebTraffic.Models;

namespace WebTraffic.Controllers
{
    public class MessageTypeController : ApiController
    {
        MessageTypeModelFactory messageTypeModelFactory;
        public MessageTypeController()
        {
            messageTypeModelFactory = new MessageTypeModelFactory();
        }

        public IEnumerable<MessageTypeModel> Get()
        {
            BusStateRepository busStateRepository = new BusStateRepository();

            return busStateRepository.GetAllMessageType().ToList().Select(x => new MessageTypeModel
            {
                messageTypeId = x.jelzesId,
                messageTypeName = x.jelzesNev.ToString()
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService;

namespace WebTraffic.Models
{
    public class MessageTypeModelFactory
    {
        public MessageTypeModel Create(Jelze state)
        {
            return new MessageTypeModel()
            {
                messageTypeId = state.jelzesId,
                messageTypeName = state.jelzesNev,
            };
        }
    }
}
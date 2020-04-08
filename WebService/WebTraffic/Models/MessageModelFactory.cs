using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService;

namespace WebTraffic.Models
{
    public class MessageModelFactory
    {
        public MessageModel Create(Uzenet message)
        {
            return new MessageModel()
            {
                MessageId = message.uzenetId,
                MessageTypeName = message.Jelze.jelzesNev,
                MessageTypeId = message.Jelze.jelzesId,
                DriverId = message.Sofor.soforId,
                DriverName = message.Sofor.soforNev,
                Line = message.Vonal.vonalId,
                Bus = message.Busz.buszId,
                MessageDate = message.datum.Value,
                MessageLon = message.lat.Value,
                MessageLat =  message.lon.Value
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService;

namespace WebTraffic.Models
{
    public class BusModelFactory
    {
        public BusModel Create(Busz bus)
        {
            return new BusModel()
            {
                BusId = bus.buszId
            };
        }

        public MessageModel Create(Uzenet message)
        {
            return new MessageModel()
            {
                MessageId = message.uzenetId,
                MessageDate = message.datum.Value
            };
        }

        public BusLineModel Create(VonalBusz linebus)
        {
            return new BusLineModel()
            {
                BusLineId = linebus.vonalbuszId,
                BusLineDate = linebus.datum.Value
            };
        }

    }
}
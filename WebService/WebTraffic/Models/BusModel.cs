using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTraffic.Models
{
    public class BusModel
    {
        public int BusId { get; set; }

        public IEnumerable<GarageModel> Garage { get; set; }
        public IEnumerable<MessageModel> Message { get; set; }
        public IEnumerable<BusLineModel> BusLine { get; set; }
        public IEnumerable<BusLineDriverModel> BusLineDriver { get; set; }
    }
}
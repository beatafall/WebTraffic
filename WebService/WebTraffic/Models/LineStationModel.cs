using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTraffic.Models
{
    public class LineStationModel
    {
        public int Id { get; set; }
        public int lineId { get; set; }
        public int stationId { get; set; }
        public string stationName { get; set; }
        public decimal lon { get; set; }
        public decimal lat { get; set; }
    }
}
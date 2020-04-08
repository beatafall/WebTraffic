using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTraffic.Models
{
    public class BusLineDriverModel
    {
        public int Id { get; set; }
        public String DriverName { get; set; }
        public int DriverId { get; set; }
        public int Line { get; set; }
        public int Bus { get; set; }
        public DateTime Date { get; set; }
    }
}
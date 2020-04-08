using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTraffic.Models
{
    public class StationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal lat { get; set; }
        public decimal lon { get; set; }
    }
}
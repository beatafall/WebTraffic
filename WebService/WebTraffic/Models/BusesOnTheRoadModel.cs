using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebTraffic.Models
{
    public class BusesOnTheRoadModel
    {
        public int Id { get; set; }
        public int Line { get; set; }
        public int Bus { get; set; }
        public decimal lon { get; set; }
        public decimal lat { get; set; }

        [DataMember]
        public System.DateTime? Date { get; set; }
    }
}   
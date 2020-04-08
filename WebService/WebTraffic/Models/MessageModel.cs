using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService;

namespace WebTraffic.Models
{
    public class MessageModel
    {
        public int MessageId { get; set; }
        public string MessageTypeName { get; set; }
        public int MessageTypeId { get; set; }
        public string DriverName { get; set; }
        public int DriverId { get; set; }
        public int Line { get; set; }
        public int Bus { get; set; }       
        public DateTime MessageDate { get; set; }
        public decimal MessageLon { get; set; }
        public decimal MessageLat { get; set; }
    }
}
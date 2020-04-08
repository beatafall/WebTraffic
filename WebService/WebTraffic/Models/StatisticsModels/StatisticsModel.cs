using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTraffic.Models.StatisticsModels
{
    public class StatisticsModel
    {
        public List<MessageModel> Messages { get; set; }

        public List<BusesOnTheRoadModel> BusesOnTheRoad { get; set; }

        public StatisticsModel()
        {
            Messages = new List<MessageModel>();

            BusesOnTheRoad = new List<BusesOnTheRoadModel>();
        }
    }
}
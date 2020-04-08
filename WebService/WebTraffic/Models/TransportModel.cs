using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTraffic.Models
{
    public class TransportModel
    {
        public List<GarageModel> BusesInTheGarage { get; set; }

        public List<StationModel> Stations { get; set; }

        public List<MessageModel> Messages { get; set; }
        
        public List<LineStationModel> LineStations { get; set; }

        public List<BusesOnTheRoadModel> BusesOnTheRoad { get; set; }

        public TransportModel()
        {
            BusesInTheGarage = new List<GarageModel>();

            Stations = new List<StationModel>();

            Messages = new List<MessageModel>();

            LineStations = new List<LineStationModel>();

            BusesOnTheRoad = new List<BusesOnTheRoadModel>();
        }
    }
}
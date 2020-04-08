using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService;

namespace WebTraffic.Models
{
    public class StationModelFactory
    {
        public StationModel Create(Megallok station)
        {
            return new StationModel()
            {
                lat = station.lon.Value,
                lon = station.lat.Value
            };
        }
    }
}
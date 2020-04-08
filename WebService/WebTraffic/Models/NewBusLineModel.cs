using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTraffic.Models
{
    public class NewBusLineModel
    {
        public List<GarageModel> BusesInTheGarage { get; set; }

        public List<LineModel> Lines { get; set; }

        public List<DriverModel> Drivers { get; set; }

        public NewBusLineModel()
        {
            BusesInTheGarage = new List<GarageModel>();

            Lines = new List<LineModel>();

            Drivers = new List<DriverModel>();
        }
    }
}
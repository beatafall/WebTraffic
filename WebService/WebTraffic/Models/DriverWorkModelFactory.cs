using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService;

namespace WebTraffic.Models
{
    public class DriverWorkModelFactory
    {
        public BusLineDriverModel Create(VonalBuszSofor d)
        {
            return new BusLineDriverModel()
            {
                Id = d.Sofor.soforId,
                DriverName = d.Sofor.soforNev,
            };
        }
    }
}
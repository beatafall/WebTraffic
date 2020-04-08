using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService;

namespace WebTraffic.Models
{
    public class DriverModelFactory
    {
        public DriverModel Create(Sofor driver)
        {
            return new DriverModel()
            {
                Id = driver.soforId,
                DriverName = driver.soforNev,
                DriverPassword = driver.soforJelszo
            };
        }
    }
}
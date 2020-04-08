using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Http.Results;
using WebService;
using WebTraffic.Models;
using System.Text;
using Newtonsoft.Json.Linq;

namespace WebTraffic.Controllers
{
    public class DriverController : ApiController
    {
        BusRepository busRepository = new BusRepository();
        BusModelFactory modelFactory;
        
        public DriverController()
        {
            modelFactory = new BusModelFactory();
        }

        public IEnumerable<DriverModel> Get()
        {
            GarageRepository garageRepository = new GarageRepository();
           
            return busRepository.GetAllDrivers().ToList().Select(x => new DriverModel
            {
                Id = x.soforId,
                DriverName = x.soforNev.ToString(),
                DriverPassword = x.soforJelszo.ToString()
            });
        }

        public IEnumerable<DriverModel> Get(int id)
        {
            GarageRepository garageRepository = new GarageRepository();
            return busRepository.GetAllDrivers().Where(g => g.soforId == id).ToList().Select(x => new DriverModel
            {
                Id=x.soforId,
                DriverName = x.soforNev.ToString(),
                DriverPassword = x.soforJelszo.ToString()
            });
        }

        
    }
}

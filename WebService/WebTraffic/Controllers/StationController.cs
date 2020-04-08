using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService;
using WebTraffic.Models;

namespace WebTraffic.Controllers
{
    public class StationController : ApiController
    {
        StationModelFactory stationFactory;
        public StationController()
        {
            stationFactory = new StationModelFactory();
        }
        public IEnumerable<StationModel> Get()
        {
            BusRepository busRepository = new BusRepository();
            return busRepository.GetAllBusStation().ToList().Select(c => stationFactory.Create(c));
        }
    }
}

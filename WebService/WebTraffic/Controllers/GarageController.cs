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
    public class GarageController : ApiController
    {
        GarageModelFactory garageModelFactory;
        public GarageController()
        {
            garageModelFactory = new GarageModelFactory();
        }

        public IEnumerable<GarageModel> Get()
        {
            GarageRepository garageRepository = new GarageRepository();        
            return garageRepository.BusInGarage().ToList().Select(x => new GarageModel
            {
                BusId = x.buszId.Value        
            }); 
        }
    }
}

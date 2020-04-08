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
    public class BusController : ApiController
    {
        BusModelFactory modelFactory;
        public BusController()
        {
            modelFactory = new BusModelFactory();
        }

        public IEnumerable<BusModel> Get()
        {
            BusRepository busRepository = new BusRepository();
            return busRepository.BusInGarage2().ToList()
                .Select(x => new BusModel {
                    BusId=x.buszId
            });
        }
    }
}

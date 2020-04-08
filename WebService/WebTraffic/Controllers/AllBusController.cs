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
    public class AllBusController : ApiController
    {
        BusModelFactory modelFactory;
        public AllBusController()
        {
            modelFactory = new BusModelFactory();
        }

        public IEnumerable<AllBusModel> Get()
        {
            BusRepository busRepository = new BusRepository();
            return busRepository.GetBus().ToList()
                .Select(x => new AllBusModel
                {
                    Bus = x.buszId
                });
        }
    }
}

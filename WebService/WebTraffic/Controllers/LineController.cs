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
    public class LineController : ApiController
    {
        BusRepository busRepository = new BusRepository();
        BusModelFactory modelFactory;

        public LineController()
        {
            modelFactory = new BusModelFactory();
        }

        public IEnumerable<LineModel> Get()
        {
            return busRepository.GetAllLines().ToList().Select(x => new LineModel
            {
                Line = x.vonalId
            });
        }
    }
}

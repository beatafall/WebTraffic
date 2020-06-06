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
    public class BusesOnTheRoadController : ApiController
    {
        BusModelFactory modelFactory;
        public BusesOnTheRoadController()
        {
            modelFactory = new BusModelFactory();
        }

        [HttpPut]
        public void Put(int id, [FromBody]Felszalla busesOnTheRoad)
        {

            using (trafficEntities dbContext = new trafficEntities())
            {
                var entity = dbContext.Felszallas.FirstOrDefault(e => e.buszId == id);
                entity.buszId = busesOnTheRoad.buszId;
                entity.vonalId = busesOnTheRoad.vonalId;
                entity.lat = busesOnTheRoad.lat;
                entity.lon = busesOnTheRoad.lon;
                entity.datum = busesOnTheRoad.datum;
                dbContext.SaveChanges();
            }
        }

        [HttpPost]
        public void Post([FromBody]Felszalla busesOnTheRoad)
        {
            using (trafficEntities db = new trafficEntities())
            {
                db.Felszallas.Add(busesOnTheRoad);
                db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<BusesOnTheRoadModel> Get()
        {
            BusRepository busRepository = new BusRepository();
            return busRepository.GetAllBusOnRoad().ToList()
                .Select(x => new BusesOnTheRoadModel
                {
                    Id = x.felszallasId,
                    Line = x.Vonal.vonalId,
                    Bus = x.Busz.buszId,
                    Date = x.datum.Value,
                    lon = x.lat.Value,
                    lat = x.lon.Value
                });
        }

        
        [HttpGet]
        public IEnumerable<BusesOnTheRoadModel> GetLines(int id)
        {
            BusRepository busRepository = new BusRepository();
            return busRepository.GetAllBusOnRoad().Where(g => g.vonalId == id)
                .ToList().Select(s => new BusesOnTheRoadModel
                {
                    Id = s.felszallasId,
                    Line = s.Vonal.vonalId,
                    Bus = s.Busz.buszId,
                    Date = s.datum.Value,
                    lon = s.lat.Value,
                    lat = s.lon.Value
                });
        }
   
    }
    }

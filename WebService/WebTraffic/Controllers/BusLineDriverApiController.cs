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
    public class BusLineDriverApiController : ApiController
    {
        [HttpGet]
        public IEnumerable<VonalBuszSofor> Get()
        {
            BusRepository busRepository = new BusRepository();
            return busRepository.GetAllLineBusDriver().ToList()
                .Select(x => new VonalBuszSofor
                {
                    vonalbuszsoforId = x.vonalbuszsoforId,
                    soforId = x.soforId,
                    vonalId = x.vonalId,
                    buszId = x.buszId,
                    datum = x.datum.Value
                });
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid student id");

            using (var DB = new trafficEntities())
            {
                var student = DB.VonalBuszSofors
                    .Where(s => s.vonalbuszsoforId == id)
                    .FirstOrDefault();

                DB.Entry(student).State = System.Data.Entity.EntityState.Deleted;
                DB.SaveChanges();
            }

            return Ok();
        }
    }
}

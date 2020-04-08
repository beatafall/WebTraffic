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
    public class BusDriverController : ApiController
    {
        //azok a soforok akik az adott datumon nem dolgoznak
        public List<BusLineDriverModel> Get()
        {
            trafficEntities obj = new trafficEntities();
            string year = DateTime.Today.Year.ToString();
            string month = DateTime.Today.Month.ToString();
            string day = DateTime.Today.Day.ToString();

            var x = from b in obj.Sofors
                    join a in obj.VonalBuszSofors
                           on b.soforId equals a.soforId
                    where a.datum.Value.Year.ToString() != year
                    || a.datum.Value.Month.ToString() != month
                    || a.datum.Value.Day.ToString() != day
                    select new BusLineDriverModel
                    {
                        Id= b.soforId,
                        DriverName = b.soforNev
                    }; 
            
            return x.Distinct().ToList();
        }

        //uj VonalBuszSofor 
        public void Post([FromBody] VonalBuszSofor newBusLineDriver)
        {
            using (trafficEntities db = new trafficEntities())
            {
                db.VonalBuszSofors.Add(newBusLineDriver);
                db.SaveChanges();
            }
        }
        
       /* public IHttpActionResult PostNewBusLineDriver(BusLineDriverModel newBusLineDriver)
         {
             if (!ModelState.IsValid)
                 return BadRequest("Not a valid model");

             using (trafficEntities db = new trafficEntities())
             {
                 db.VonalBuszSofors.Add(new VonalBuszSofor()
                 {
                     vonalbuszsoforId = newBusLineDriver.Id,
                     buszId = newBusLineDriver.Bus,
                     vonalId = newBusLineDriver.Line,
                     soforId = newBusLineDriver.DriverId,
                     datum = newBusLineDriver.Date
                 });

                db.SaveChanges();
             }

             return Ok();
         }*/
    }
}

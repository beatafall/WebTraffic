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
    public class LineStationController : ApiController
    {
        BusModelFactory modelFactory;
        public LineStationController()
        {
            modelFactory = new BusModelFactory();
        }

       public IEnumerable<LineStationModel> Get()
        {
            BusRepository busRepository = new BusRepository();
            return busRepository.GetAllLineStation().ToList()
                .Select(x => new LineStationModel
                {
                    Id = x.vonalMegalloiId,
                    lineId = x.Vonal.vonalId,
                    stationId = x.Megallok.megalloId,
                    stationName = x.Megallok.megalloNev,
                    lon = x.Megallok.lat.Value,
                    lat = x.Megallok.lon.Value
                });
        }

        public IHttpActionResult GetLines(int line)
        {
            LineStationModel lines = null;

            using (var ctx = new trafficEntities())
            {
                lines = ctx.VonalMegalloks
                    .Where(s => s.vonalId == line)
                    .Select(s => new LineStationModel()
                    {
                        Id = s.vonalMegalloiId,
                        lineId = s.Vonal.vonalId,
                        stationId = s.Megallok.megalloId,
                        stationName = s.Megallok.megalloNev,
                        lon = s.Megallok.lat.Value,
                        lat = s.Megallok.lon.Value
                    }).FirstOrDefault<LineStationModel>();
            }

            if (lines == null)
            {
                return NotFound();
            }

            return Ok(lines);
        }
    }
}

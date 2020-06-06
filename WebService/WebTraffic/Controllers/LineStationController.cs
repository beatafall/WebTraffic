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

       
        public IEnumerable<LineStationModel> GetLines(int id)
        {
            BusRepository busRepository = new BusRepository();
            return busRepository.GetAllLineStation().Where(g => g.vonalId == id)
                .ToList().Select(x => new LineStationModel
            {
                Id = x.vonalMegalloiId,
                lineId = x.Vonal.vonalId,
                stationId = x.Megallok.megalloId,
                stationName = x.Megallok.megalloNev,
                lon = x.Megallok.lat.Value,
                lat = x.Megallok.lon.Value
            });
        }


    }
}

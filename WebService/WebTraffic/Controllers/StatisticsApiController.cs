using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using WebService;
using WebTraffic.Models;
using WebTraffic.Models.StatisticsModels;

namespace WebTraffic.Controllers
{
    public class StatisticsApiController : ApiController
    {
        trafficEntities db = new trafficEntities();

        [System.Web.Http.HttpGet]
        public IHttpActionResult list()
        {
    
            var query = from r in db.Uzenets
                        let dt = r.datum.Value
                        where r.Jelze.jelzesId.Equals(1)
                        group r by new { y = dt.Year, m = dt.Month, d = dt.Day, h = dt.Hour, min = dt.Minute, mill = dt.Millisecond } into g
                        select new { Date = g.Key.h , numberOfTraffic = g.Count() }; 
  

            var accidents = query.ToList();

            List<TrafficTimeModel> list = new List<TrafficTimeModel>();

            foreach (var item in accidents)
            {

                list.Add(new TrafficTimeModel()
                {
                    DateTime = item.Date.ToString(),
                    Counter = item.numberOfTraffic
                });
                
            }
            return Json(list);

        }
        
    }
}

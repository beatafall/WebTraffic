using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebService;
using WebTraffic.Models;
using WebTraffic.Models.StatisticsModels;

namespace WebTraffic.Controllers
{
    public class StatisticsController : Controller
    {
        trafficEntities db = new trafficEntities();
        BusRepository messageRepository = new BusRepository();

        // GET: Statistics
        public ActionResult Statistics()
        {
            StatisticsModel m = new StatisticsModel();

            List<Uzenet> messageItems = messageRepository.GetAllMessage();
            List<Felszalla> busesOnTheRoad = messageRepository.GetAllBusOnRoad();

            var config = new MapperConfiguration(cfg => {
              
                cfg.CreateMap<Uzenet, MessageModel>()
                    .ForMember(x => x.MessageId, x => x.MapFrom(y => y.uzenetId))
                    .ForMember(x => x.DriverName, x => x.MapFrom(y => y.Sofor.soforNev))
                    .ForMember(x => x.MessageTypeName, x => x.MapFrom(y => y.Jelze.jelzesNev))
                    .ForMember(x => x.Line, x => x.MapFrom(y => y.Vonal.vonalId))
                    .ForMember(x => x.Bus, x => x.MapFrom(y => y.Busz.buszId))
                    .ForMember(x => x.MessageDate, x => x.MapFrom(y => y.datum))
                    .ForMember(x => x.MessageLat, x => x.MapFrom(y => y.lon))
                    .ForMember(x => x.MessageLon, x => x.MapFrom(y => y.lat));

                cfg.CreateMap<Felszalla, BusesOnTheRoadModel>()
                 .ForMember(x => x.Id, x => x.MapFrom(y => y.felszallasId))
                 .ForMember(x => x.Line, x => x.MapFrom(y => y.vonalId))
                 .ForMember(x => x.lat, x => x.MapFrom(y => y.lat))
                 .ForMember(x => x.lon, x => x.MapFrom(y => y.lon))
                 .ForMember(x => x.Date, x => x.MapFrom(y => y.datum));

            });

            IMapper mapper = config.CreateMapper();

            m.Messages = mapper.Map<ICollection<Uzenet>, List<MessageModel>>(messageItems);
            m.BusesOnTheRoad = mapper.Map<ICollection<Felszalla>, List<BusesOnTheRoadModel>>(busesOnTheRoad);

            return View(m); ;
        }

        [HttpPost]
        public JsonResult GetAccidents()
        {
            var query = from r in db.Uzenets
                        join p in db.Sofors
                        on r.soforId equals p.soforId
                        where r.Jelze.jelzesId.Equals(5)
                        group p by new { p.soforNev } into g
                        select new { DriverName = g.Key.soforNev, numberOfAccident = g.Count() };


            var accidents = query.ToList();

            List<AccidentModel> list = new List<AccidentModel>();

            foreach (var item in accidents)
            {

                list.Add(new AccidentModel()
                {
                    DriverName = item.DriverName,
                    CountAccident = item.numberOfAccident
                });

            }
            return Json(list);

        }

        [HttpPost]
        public JsonResult GetCrowdedLines()
        {

            var query = from r in db.Uzenets
                        where r.Jelze.jelzesId.Equals(2)
                        group r by new { r.vonalId } into g
                        select new { line = g.Key.vonalId, counter = g.Count() };


            var crowededlinesList = query.ToList();

            List<CrowdedLinesModel> list = new List<CrowdedLinesModel>();

            foreach (var item in crowededlinesList)
            {

                list.Add(new CrowdedLinesModel()
                {
                    Line = item.line.ToString(),
                    CrowdedCounter = item.counter
                });

            }
            return Json(list);

        }

        [HttpPost]
        public JsonResult GetCrasdedBuses()
        {

            var query = from r in db.Uzenets
                        where r.Jelze.jelzesId.Equals(3)
                        group r by new { r.buszId } into g
                        select new { bus = g.Key.buszId, counter = g.Count() };


            var crashedbusesList = query.ToList();

            List<BusCrashedModel> list = new List<BusCrashedModel>();

            foreach (var item in crashedbusesList)
            {

                list.Add(new BusCrashedModel()
                {
                    Bus = item.bus.ToString(),
                    BusCrashedCounter = item.counter
                });

            }
            return Json(list);

        }

        [HttpPost]
        public JsonResult GetTrafficTime()
        {
            var query = from r in db.Uzenets
                        let dt = r.datum.Value
                        where r.Jelze.jelzesId.Equals(1)
                        group r by new { h = dt.Hour } into g
                        select new { Date = g.Key.h, numberOfTraffic = g.Count() };


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

        [HttpPost]
        public JsonResult GetCrowdedBusesTime()
        {
            var query = from r in db.Uzenets
                        let dt = r.datum.Value
                        where r.Jelze.jelzesId.Equals(2)
                        group r by new { h = dt.Hour } into g
                        select new { Date = g.Key.h, counter = g.Count() };


            var accidents = query.ToList();

            List<TrafficTimeModel> list = new List<TrafficTimeModel>();

            foreach (var item in accidents)
            {

                list.Add(new TrafficTimeModel()
                {
                    DateTime = item.Date.ToString(),
                    Counter = item.counter
                });

            }
            return Json(list);

        }
    }
}
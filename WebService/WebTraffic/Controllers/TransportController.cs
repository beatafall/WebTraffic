using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebService;
using WebTraffic.Models;

namespace WebTraffic.Controllers
{
    public class TransportController : Controller
    {

        GarageRepository garageRepository = new GarageRepository();
        BusStateRepository busStationRepository = new BusStateRepository();
        BusRepository messageRepository = new BusRepository();

        public ActionResult Index()
        {
            TransportModel m = new TransportModel();

            List<Garaz> garageItems = garageRepository.GetAllBusState();
            List<Megallok> busStationItems = busStationRepository.GetAllStation();
            List<Uzenet> messageItems = messageRepository.GetAllMessage();
            List<VonalMegallok> lineStationsItems = messageRepository.GetAllLineStation();
            List<Felszalla> busesOnTheRoad = messageRepository.GetAllBusOnRoad();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Megallok, StationModel>()
                    .ForMember(x => x.Id, x => x.MapFrom(y => y.megalloId))
                    .ForMember(x => x.Name, x => x.MapFrom(y => y.megalloNev))
                    .ForMember(x => x.lat, x => x.MapFrom(y => y.lat))
                    .ForMember(x => x.lon, x => x.MapFrom(y => y.lon));

                cfg.CreateMap<Garaz, GarageModel>()
                    //.ForMember(x => x.GarageId, x => x.MapFrom(y => y.garazsid))
                    .ForMember(x => x.BusId, x => x.MapFrom(y => y.buszId));

                cfg.CreateMap<Uzenet, MessageModel>()
                    .ForMember(x => x.MessageId, x => x.MapFrom(y => y.uzenetId))
                    .ForMember(x => x.DriverName, x => x.MapFrom(y => y.Sofor.soforNev))
                    .ForMember(x => x.MessageTypeName, x => x.MapFrom(y => y.Jelze.jelzesNev))
                    .ForMember(x => x.Line, x => x.MapFrom(y => y.Vonal.vonalId))
                    .ForMember(x => x.Bus, x => x.MapFrom(y => y.Busz.buszId))
                    .ForMember(x => x.MessageDate, x => x.MapFrom(y => y.datum))
                    .ForMember(x => x.MessageLat, x => x.MapFrom(y => y.lon))
                    .ForMember(x => x.MessageLon, x => x.MapFrom(y => y.lat));


                cfg.CreateMap<VonalMegallok, LineStationModel>()                
                    .ForMember(x => x.Id, x => x.MapFrom(y => y.vonalMegalloiId))
                    .ForMember(x => x.lineId, x => x.MapFrom(y => y.vonalId))
                    .ForMember(x => x.stationId, x => x.MapFrom(y => y.megalloId))
                    .ForMember(x => x.lat, x => x.MapFrom(y => y.Megallok.lat))
                    .ForMember(x => x.lon, x => x.MapFrom(y => y.Megallok.lon))
                    .ForMember(x => x.stationName, x => x.MapFrom(y => y.Megallok.megalloNev));

                cfg.CreateMap<Felszalla, BusesOnTheRoadModel>()
                   .ForMember(x => x.Id, x => x.MapFrom(y => y.felszallasId))
                   .ForMember(x => x.Line, x => x.MapFrom(y => y.vonalId))
                   .ForMember(x => x.lat, x => x.MapFrom(y => y.lat))
                   .ForMember(x => x.lon, x => x.MapFrom(y => y.lon))
                   .ForMember(x => x.Date, x => x.MapFrom(y => y.datum));

            });

            IMapper mapper = config.CreateMapper();


            m.BusesInTheGarage = mapper.Map<ICollection<Garaz>, List<GarageModel>>(garageItems);
            m.Stations = mapper.Map<ICollection<Megallok>, List<StationModel>>(busStationItems);
            m.Messages = mapper.Map<ICollection<Uzenet>, List<MessageModel>>(messageItems);
            m.LineStations = mapper.Map<ICollection<VonalMegallok>, List<LineStationModel>>(lineStationsItems);
            m.BusesOnTheRoad = mapper.Map<ICollection<Felszalla>, List<BusesOnTheRoadModel>>(busesOnTheRoad);

            return View(m);
        }

        [HttpPost]
        public ContentResult GetCurrentDate()
        {
            string currentDate = string.Format(DateTime.Now.ToString());
            return Content(currentDate);
        }
    }
}
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
    public class BusLineDriverController : Controller
    {
        GarageRepository garageRepository = new GarageRepository();
        BusRepository busRepository = new BusRepository();
        
        public ActionResult BusLineDriver()
        {
            NewBusLineModel m = new NewBusLineModel();

            List<Garaz> garageItems = garageRepository.GetAllBusState();
            List<Vonal> lineItems = busRepository.GetAllLines();
            List<Sofor> drivers = busRepository.GetAllDrivers();

            var config = new MapperConfiguration(cfg => {              

                cfg.CreateMap<Garaz, GarageModel>()
                    .ForMember(x => x.BusId, x => x.MapFrom(y => y.buszId));

                cfg.CreateMap<Vonal, LineModel>()
                    .ForMember(x => x.Line, x => x.MapFrom(y => y.vonalId));

                cfg.CreateMap<Sofor, DriverModel>()
                    .ForMember(x => x.Id, x => x.MapFrom(y => y.soforId))
                    .ForMember(x => x.DriverName, x => x.MapFrom(y => y.soforNev));
            });

            IMapper mapper = config.CreateMapper();


            m.BusesInTheGarage = mapper.Map<ICollection<Garaz>, List<GarageModel>>(garageItems);
            m.Lines = mapper.Map<ICollection<Vonal>, List<LineModel>>(lineItems);
            m.Drivers = mapper.Map<ICollection<Sofor>, List<DriverModel>>(drivers);

            return View(m);
        }

        [HttpPost]
        public ActionResult addNewBusLineDriver(VonalBuszSofor newBusLineDriver)
        {

            using (trafficEntities db = new trafficEntities())
            {
                db.VonalBuszSofors.Add(newBusLineDriver);

                db.SaveChanges();
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View("addNewBusLineDriver", new VonalBuszSofor());
        }

    }
}
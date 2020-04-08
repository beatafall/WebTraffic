using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService
{
    public class BusRepository
    {
        public List<Busz> GetBus()
        {
            trafficEntities DB = new trafficEntities();
            return DB.Buszs.ToList();
        }

        public IQueryable<Busz> GetAllBus()
        {
            trafficEntities DB = new trafficEntities();
            return DB.Buszs;
        }

        public IQueryable<Busz> GetAllBus(int id)
        {
            trafficEntities DB = new trafficEntities();
            return DB.Buszs.Where(c => c.buszId == id).Select(e => e);
        }

        public IQueryable<Busz> BusInGarage2()
        {
            trafficEntities DB = new trafficEntities();
            return DB.Buszs.Where(b => b.buszId == 123).Select(b => b);
        }

        //osszes megallo lekerdezese
        public IQueryable<Megallok> GetAllBusStation()
        {
            trafficEntities DB = new trafficEntities();
            return DB.Megalloks;
        }

        //osszes sofor lekerdezese
        public List<Sofor> GetAllDrivers()
        {
            trafficEntities DB = new trafficEntities();
            return DB.Sofors.ToList();
        }

        //osszes VonalBusSofor lekerdezese
        public List<VonalBuszSofor> GetAllLineBusDriver()
        {
            trafficEntities DB = new trafficEntities();
            return DB.VonalBuszSofors.ToList();
        }

        public List<Uzenet> GetAllMessage()
        {
            trafficEntities DB = new trafficEntities();
            return DB.Uzenets.ToList();
        }

        public List<Uzenet> GetAccidents()
        {
            trafficEntities DB = new trafficEntities();
            return DB.Uzenets.ToList();
        }

        public List<Vonal> GetAllLines()
        {
            trafficEntities DB = new trafficEntities();
            return DB.Vonals.ToList();
        }

        public IList<Uzenet> GetMessages()
        {
            trafficEntities DB = new trafficEntities();
            return DB.Uzenets.ToList();
        }

        public List<VonalMegallok> GetAllLineStation()
        {
            trafficEntities DB = new trafficEntities();
            return DB.VonalMegalloks.ToList();
        }

        public List<Felszalla> GetAllBusOnRoad()
        {
            trafficEntities DB = new trafficEntities();
            return DB.Felszallas.ToList();
        }

    } 
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService
{
    public class BusStateRepository
    {
        public List<Megallok> GetAllStation()
        {
            trafficEntities DB = new trafficEntities();
            return DB.Megalloks.ToList();
        }

        public IQueryable<Jelze> GetAllMessageType()
        {
            trafficEntities DB = new trafficEntities();
            return DB.Jelzes;
        }

        /*public IQueryable<Megallok> GetAllStation()
        {
            trafficEntities DB = new trafficEntities();
            return DB.Megalloks;
        }*/

        public IQueryable<Megallok> GetAllStation(int id)
        {
            trafficEntities DB = new trafficEntities();
            return DB.Megalloks.Where(b => b.megalloId == id).Select(e => e);
        }
        /*
        public IQueryable<BuszAllapot> GetAllBusState()
        {
            trafficEntities DB = new trafficEntities();
            return DB.BuszAllapots;
        }

        public IQueryable<BuszAllapot> GetAllBusState(int id)
        {
            trafficEntities DB = new trafficEntities();
            return DB.BuszAllapots.Where(c => c.buszAllapotId == id).Select(e => e);
        }*/
    }
}

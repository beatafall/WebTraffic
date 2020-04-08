using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService
{
    class BusStationRepository
    {
        public IQueryable<Megallok> GetAllStation()
        {
            trafficEntities DB = new trafficEntities();
            return DB.Megalloks;
        }

        public IQueryable<Megallok> GetAllStation(int id)
        {
            trafficEntities DB = new trafficEntities();
            return DB.Megalloks.Where(b => b.megalloId == id).Select(e => e);
        }
    }
}

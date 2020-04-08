using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService
{
    public class GarageRepository
    {
        public List<Garaz> GetAllBusState()
        {
            trafficEntities DB = new trafficEntities();
            return DB.Garazs.ToList();
        }

        public IQueryable<Garaz> GetAllBusState(int id)
        {
            trafficEntities DB = new trafficEntities();
            return DB.Garazs.Where(c => c.garazsid == id).Select(e => e);
        }

        //buszok melyek a garazsban vannak
        public IQueryable<Garaz> BusInGarage()
        {
            trafficEntities DB = new trafficEntities();
            return DB.Garazs.Where(g => g.BuszAllapot.buszAllapot1 == "garazsban");
        }

    }
}

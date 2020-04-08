using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService
{
    class MessageRepository
    {
        public IQueryable<Uzenet> GetAllMessage()
        {
            trafficEntities DB = new trafficEntities();
            return DB.Uzenets;
        }
    }
}

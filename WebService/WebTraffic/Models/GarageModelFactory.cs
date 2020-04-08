using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService;

namespace WebTraffic.Models
{
    public class GarageModelFactory
    {
        public GarageModel Create(Garaz garage)
        {
            return new GarageModel()
            {
                //GarageId = garage.garazsid,

                BusId = garage.buszId.Value,

            };
        }
    }
}
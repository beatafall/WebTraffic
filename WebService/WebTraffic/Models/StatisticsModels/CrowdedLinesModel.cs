using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTraffic.Models.StatisticsModels
{
    public class CrowdedLinesModel
    {
        public string Line { get; set; }
        public int CrowdedCounter { get; set; }
    }
}
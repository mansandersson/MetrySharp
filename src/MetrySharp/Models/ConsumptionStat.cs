using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetrySharp.Models
{
    public class ConsumptionStat
    {
        public ConsumptionAggregate Hour { get; set; }
        public ConsumptionAggregate Day { get; set; }
        public ConsumptionAggregate Month { get; set; }
    }
}

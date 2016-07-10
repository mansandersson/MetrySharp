using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MetrySharp.Models
{
    /// <summary>
    /// Consumption for a period of time (hour/day/month).
    /// </summary>
    public class ConsumptionPeriod
    {
        /// <summary>
        /// Period start date
        /// </summary>
        [JsonProperty(PropertyName = "start_date")]
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Period end date
        /// </summary>
        [JsonProperty(PropertyName = "end_date")]
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Energy consumption
        /// </summary>
        public List<double> Energy { get; set; }
        /// <summary>
        /// Flow consumption
        /// </summary>
        public List<double> Flow { get; set; }
        /// <summary>
        /// Power consumption
        /// </summary>
        public List<double> Power { get; set; }
    }
}

using System.Collections.Generic;
using Newtonsoft.Json;

namespace MetrySharp.Models
{
    /// <summary>
    /// Consumption
    /// </summary>
    public class Consumption
    {
        /// <summary>
        /// The id of the meter to get consumption data for.
        /// </summary>
        [JsonProperty(PropertyName = "meter_id")]
        public string MeterId { get; set; }
        /// <summary>
        /// The granularity of the periods.
        /// </summary>
        public string Granularity { get; set; }
        /// <summary>
        /// List of periods.
        /// </summary>
        public List<ConsumptionPeriod> Periods { get; set; }
    }
}

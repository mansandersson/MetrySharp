using System.Collections.Generic;
using Newtonsoft.Json;

namespace MetrySharp.Models
{
    /// <summary>
    /// Meter
    /// </summary>
    public class Meter
    {
        /// <summary>
        /// Unique identifier for the meter.
        /// </summary>
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }
        /// <summary>
        /// Holder of the meter.
        /// </summary>
        public Account Holder { get; set; }
        /// <summary>
        /// Who assigned the meter to the holder; authorized to revoke access at anytime.
        /// </summary>
        public Account Assigner { get; set; }
        /// <summary>
        /// The level of control the holder has on the meter. "Owned" represents the highest level of control. Possible values: owned, subscribed, shared.
        /// </summary>
        [JsonProperty(PropertyName = "control_level")]
        public string ControlLevel { get; set; }

        /// <summary>
        /// Meter name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Timezone
        /// </summary>
        public string Timezone { get; set; }

        /// <summary>
        /// Active meters has access to consumption values.
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// If revoked the assigner of the meter has decided to deny the holder access, often because
        /// the holder's subscription has been canceled at the root holder.
        /// </summary>
        public bool Revoked { get; set; }

        /// <summary>
        /// What type of consumption the meter represents. Possible values: electricity, heat, cooling, gas, water
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// The expected granularity. Possible values: hour, day, month
        /// </summary>
        [JsonProperty(PropertyName = "expected_granularity")]
        public string ExpectedGranularity { get; set; }
        /// <summary>
        /// What type of metrics can be expected from the meter. Possible values: energy (kWh), flow (m3), power (kW)
        /// </summary>
        public List<string> Metrics { get; set; }
        /// <summary>
        /// List of tags
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// Information about what data that is available for the meter.
        /// </summary>
        [JsonProperty(PropertyName = "consumption_stats")]
        public Dictionary<string, ConsumptionStat> ConsumptionStats { get; set; }
    }
}

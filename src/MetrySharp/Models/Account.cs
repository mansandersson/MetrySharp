using System;
using Newtonsoft.Json;

namespace MetrySharp.Models
{
    /// <summary>
    /// Account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Account id
        /// </summary>
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// User name
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Creation date
        /// </summary>
        public DateTime Created { get; set; }
    }
}

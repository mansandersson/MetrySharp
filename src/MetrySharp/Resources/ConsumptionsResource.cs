using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MetrySharp.Models;

namespace MetrySharp.Resources
{
    /// <summary>
    /// Class for getting consumption data
    /// </summary>
    public class ConsumptionsResource : Resource
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client">MetryClient object</param>
        public ConsumptionsResource(MetryClient client)
            : base(client)
        {

        }

        /// <summary>
        /// Get consumption for a meter.
        /// </summary>
        /// <param name="meterId">Id of meter</param>
        /// <param name="granularity">Granularity, possible values: hour, day, month</param>
        /// <param name="period">Period, e.g. 2016, 201607, 20160710</param>
        /// <returns>Consumption for the specified period</returns>
        public async Task<MetryResponse<List<Consumption>>> GetConsumption(string meterId, string granularity, string period)
        {
            MetryResponse<List<Consumption>> response =  await Client.GetAsync<MetryResponse<List<Consumption>>>(String.Format("consumptions/{0}/{1}/{2}", meterId, granularity, period));
            if (response.Data != null)
            {
                response.Data.ForEach((i) => { i.Granularity = granularity; });
            }
            return response;
        }
    }
}

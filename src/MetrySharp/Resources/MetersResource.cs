using System;
using System.Threading.Tasks;
using MetrySharp.Models;

namespace MetrySharp.Resources
{
    /// <summary>
    /// Class for getting meters data
    /// </summary>
    public class MetersResource : Resource
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client">MetryClient object</param>
        public MetersResource(MetryClient client)
            : base(client)
        {

        }

        /// <summary>
        /// Get a list of meters available to the user
        /// </summary>
        /// <returns></returns>
        public async Task<MetryPaginatedResponse<Meter>> GetMeters()
        {
            return await Client.GetAsync<MetryPaginatedResponse<Meter>>("meters");
        }

        /// <summary>
        /// Get a specific meter
        /// </summary>
        /// <param name="id">Meter id</param>
        /// <returns></returns>
        public async Task<MetryResponse<Meter>> GetMeter(string id)
        {
            return await Client.GetAsync<MetryResponse<Meter>>(String.Format("meters/", id));
        }
    }
}

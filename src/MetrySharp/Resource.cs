using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetrySharp
{
    /// <summary>
    /// General resource model
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// MetryClient object for communicating
        /// </summary>
        protected MetryClient Client { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client">MetryClient object</param>
        public Resource(MetryClient client)
        {
            this.Client = client;
        }
    }
}

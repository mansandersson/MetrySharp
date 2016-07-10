using System;
using System.Threading.Tasks;
using MetrySharp.Models;

namespace MetrySharp.Resources
{
    /// <summary>
    /// Class for getting account data
    /// </summary>
    public class AccountsResource : Resource
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client">MetryClient object</param>
        public AccountsResource(MetryClient client)
            : base(client)
        {

        }

        /// <summary>
        /// Get account data
        /// </summary>
        /// <param name="id">Account id, or me to get current user</param>
        /// <returns></returns>
        public async Task<MetryResponse<Account>> GetAccount(string id = "me")
        {
            return await Client.GetAsync<MetryResponse<Account>>(String.Format("accounts/{0}", id));
        }
    }
}

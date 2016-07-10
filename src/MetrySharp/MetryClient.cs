using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MetrySharp.Resources;
using Newtonsoft.Json;

namespace MetrySharp
{
    /// <summary>
    /// Client for communicationg with Metry (metry.io)
    /// </summary>
    public class MetryClient
    {
        private readonly HttpClient _http;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public MetryClient(MetryConfiguration configuration)
        {
            _http = new HttpClient()
            {
                BaseAddress = new Uri(configuration.BaseAddress)
            };

            _http.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", configuration.AccessToken));
        }

        #region HTTP REST Communication
        internal Task<T> GetAsync<T>(string method)
        {
            return SendAsync<T>(method, null, HttpMethod.Get);
        }

        internal Task<T> PostAsync<T>(string method, object data)
        {
            return SendAsync<T>(method, data, HttpMethod.Post);
        }

        internal Task<T> PutAsync<T>(string method, object data)
        {
            return SendAsync<T>(method, data, HttpMethod.Put);
        }

        internal Task<T> DeleteAsync<T>(string method)
        {
            return DeleteAsync<T>(method, null);
        }

        internal Task<T> DeleteAsync<T>(string method, object data)
        {
            return SendAsync<T>(method, data, HttpMethod.Delete);
        }

        private async Task<T> SendAsync<T>(string method, object data, HttpMethod httpMethod)
        {
            var request = new HttpRequestMessage(httpMethod, method);

            if (data != null)
            {
                request.Content = GetFormUrlEncodedContent(data);
            }

            using (request)
            using (var response = await _http.SendAsync(request).ConfigureAwait(false))
            using (var content = response.Content)
            using (var stream = await content.ReadAsStreamAsync())
            using (var reader = new StreamReader(stream))
            {
                var json = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        private static StringContent GetFormUrlEncodedContent(object obj)
        {
            var properties = from pi in obj.GetType().GetProperties()
                             where pi.GetValue(obj, null) != null
                             select new KeyValuePair<string, string>(WebUtility.UrlEncode(pi.Name), WebUtility.UrlEncode(pi.GetValue(obj, null).ToString()));
            var dict = properties.ToDictionary((k) => k.Key, (k) => k.Value);
            var postData = string.Join("&",
                dict.Select(kvp =>
                    string.Format("{0}={1}", kvp.Key, kvp.Value)));

            return new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded");
        }
        #endregion

        private AccountsResource _accounts { get; set; }
        /// <summary>
        /// Accounts resource
        /// </summary>
        public AccountsResource Accounts
        {
            get
            {
                return _accounts ?? (_accounts = new AccountsResource(this));
            }
        }

        private MetersResource _meters { get; set; }
        /// <summary>
        /// Meters resource
        /// </summary>
        public MetersResource Meters
        {
            get
            {
                return _meters ?? (_meters = new MetersResource(this));
            }
        }

        private ConsumptionsResource _consumptions { get; set; }
        /// <summary>
        /// Consumptions resource
        /// </summary>
        public ConsumptionsResource Consumptions
        {
            get
            {
                return _consumptions ?? (_consumptions = new ConsumptionsResource(this));
            }
        }
    }
}
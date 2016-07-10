using System.Net;

namespace MetrySharp.Models
{
    /// <summary>
    /// General responnse model
    /// </summary>
    /// <typeparam name="T">Response type</typeparam>
    public class MetryResponse<T>
    {
        /// <summary>
        /// Whether response code indicates an ok response
        /// </summary>
        public bool IsOk
        {
            get
            {
                return (Code == HttpStatusCode.OK);
            }
        }
        /// <summary>
        /// Http status code
        /// </summary>
        public HttpStatusCode Code { get; set; }
        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Data
        /// </summary>
        public T Data { get; set; }
    }
}

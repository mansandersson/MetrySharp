namespace MetrySharp
{
    /// <summary>
    /// Configuration for communicating with Metry
    /// </summary>
    public class MetryConfiguration
    {
        /// <summary>
        /// Access token
        /// </summary>
        public string AccessToken { get; set; }
        private string _baseAddress;
        /// <summary>
        /// Base address
        /// </summary>
        public string BaseAddress
        {
            get
            {
                return _baseAddress;
            }
            set
            {
                if (!value.EndsWith("/"))
                    this._baseAddress = value + "/";
                else
                    this._baseAddress = value;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public MetryConfiguration()
        {
            BaseAddress = "http://app.metry.io/api/v2/";
        }

    }
}

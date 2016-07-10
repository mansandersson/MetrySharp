using System.Collections.Generic;

namespace MetrySharp.Models
{
    public class MetryPaginatedResponse<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public List<T> Data { get; set; }
        public int Count { get; set; }
        public int Skip { get; set; }
        public int Limit { get; set; }
    }
}

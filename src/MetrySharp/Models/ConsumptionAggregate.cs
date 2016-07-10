namespace MetrySharp.Models
{
    public class ConsumptionAggregate
    {
        public int Count { get; set; }
        public int First { get; set; }
        public int Last { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Sum { get; set; }
    }
}

namespace TM.Domain.Entities
{
    public class AssetRate
    {
        public required string AssetName { get; set; }
        public decimal LastPrice { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public decimal Volume { get; set; }
        public decimal WeightedAveragePrice { get; set; }

    }
}

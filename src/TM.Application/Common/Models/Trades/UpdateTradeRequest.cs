namespace TM.Application.Common.Models.Trades
{
    public class UpdateTradeRequest : CreateTradeRequest
    {
        public string? ID { get; set; }
        public string? ResultType { get; set; }
        public double? Profit { get; set; }

    }
}

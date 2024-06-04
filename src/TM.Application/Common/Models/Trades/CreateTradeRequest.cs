namespace TM.Application.Common.Models.Trades
{
    public class CreateTradeRequest
    {
        public required string UserID { get; set; }
        public required string SetupID { get; set; }
        public required string PairID { get; set; }

        public DateTime Date { get; set; }

        public required double InitialDeposit { get; set; }
        public required double PriceEntry { get; set; }
        public required double PriceStop { get; set; }
        public required double PriceTake { get; set; }

        public required double DepositRisk { get; set; }

        public required string PositionType { get; set; }
        public required string DirectionType { get; set; }
        public int Rating { get; set; }

    }
}

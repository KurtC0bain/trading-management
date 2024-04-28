using TM.Domain.Enums;

namespace TM.Domain.Entities
{
    public class Trade
    {
        public string ID { get; set; }
        public string UserID { get; set; }
        public string SetupID { get; set; }
        public string PairID { get; set; }

        public DateTime Date { get; set; }

        public required double InitialDeposit { get; set; }
        public double RiskAmount { get; set; }
        public required double PriceEntry { get; set; }
        public required double PriceStop { get; set; }
        public required double PriceTake { get; set; }

        public double Profit { get; set; }
        public double DepositRisk { get; set; }
        public double RiskRewardRatio { get; set; }


        public PositionType PositionType { get; set; }
        public DirectionType DirectionType { get; set; }
        public ResultType? ResultType { get; set; }
        public int Rating { get; set; }

        //Navigation
        public Setup? Setup { get; set; }
        public Pair Pair { get; set; }


        public override string ToString()
        {
            return $"{Pair} - {Date} - {Profit} - {ResultType}";
        }
    }
}

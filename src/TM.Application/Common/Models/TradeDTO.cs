using TM.Domain.Entities;
using TM.Domain.Enums;

namespace TM.Application.Common.Models
{
    public class TradeDTO
    {
        public string? ID { get; set; } // on back-end
        public string? UserID { get; set; }
        public string SetupID { get; set; }
        public string PairID { get; set; }

        public DateTime Date { get; set; } // on back-end

        public required double InitialDeposit { get; set; }
        public double RiskAmount { get; set; } // on back-end
        public required double PriceEntry { get; set; }
        public required double PriceStop { get; set; }
        public required double PriceTake { get; set; }

        public double Profit { get; set; } // on back-end
        public required double DepositRisk { get; set; }
        public double? RiskRewardRatio { get; set; }// on back-end

        public string PositionType { get; set; }
        public string DirectionType { get; set; }
        public string? ResultType { get; set; }
        public int Rating { get; set; }
    }
}

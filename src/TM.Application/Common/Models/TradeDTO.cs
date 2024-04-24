using TM.Domain.Entities;
using TM.Domain.Enums;

namespace TM.Application.Common.Models
{
    public class TradeDTO
    {
        public required string PairID { get; set; }
        public double Price { get; set; }
        public PositionType PositionType { get; set; }
        public DirectionType DirectionType { get; set; }
        public int Rating { get; set; }
        public double BudgetRisk { get; set; }
        public double RiskRevardRatio { get; set; }
        public ResultType ResultType { get; set; }
        public double Profit { get; set; }
        public List<string>? FactorsIDs { get; set; }
        public string SetupID { get; set; }

    }
}

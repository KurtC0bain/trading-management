using TM.Domain.Enums;

namespace TM.Domain.Entities
{
    public class Trade
    {
        public Guid ID { get; set; }
        public required string UserID { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public PositionType PositionType { get; set; }
        public DirectionType DirectionType { get; set; }
        public bool IsTest => Setup is null;
        public int Rating { get; set; }
        public double BudgetRisk { get; set; }
        public double RiskRevardRatio { get; set; }
        public ResultType ResultType { get; set; }
        public double Profit { get; set; }
        
        //Navigation
        public IEnumerable<Factor>? Factors { get; set; }
        public Setup? Setup { get; set; }
        public required Pair Pair { get; set; }


        public override string ToString()
        {
            return $"{Pair} - {Date} - {Price} - {ResultType}";
        }
    }
}

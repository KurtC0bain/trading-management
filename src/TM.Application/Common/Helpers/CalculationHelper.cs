using TM.Domain.Enums;

namespace TM.Application.Common.Helpers
{
    public static class CalculationHelper
    {
        public static double GetRiskRewardRatio(double entry, double stop, double take) => Math.Round((take - entry) / (entry - stop), 2);

        public static double GetProfit(double entry, double stop, double take, double risk, double initialDeposit, PositionType positionType)
        {

            if(positionType == PositionType.Long)
            {
                var persentageOfEntry = 100 / ((1 - stop / entry)) * risk / 100;

                var sumOfEntry = initialDeposit * persentageOfEntry / 100;

                return Math.Round((take / entry - 1) * sumOfEntry, 5);
            }
            else if(positionType == PositionType.Short)
            {
                var persentageOfEntry = 100 / ((stop / entry - 1)) * risk / 100;

                var sumOfEntry = initialDeposit * persentageOfEntry / 100;

                return Math.Round((1 - take / entry) * sumOfEntry, 5);
            }
            return 0;

        }

        public static double GetRiskAmount(double initialDeposit,  double risk) => Math.Round(initialDeposit * risk / 100, 5);
    }
}

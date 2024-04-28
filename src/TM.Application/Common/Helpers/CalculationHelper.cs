using TM.Domain.Enums;

namespace TM.Application.Common.Helpers
{
    public static class CalculationHelper
    {
        public static double GetRiskRewardRatio(double entry, double stop, double take)
        {
            return (take - entry) / (entry - stop);
        }

        public static double GetProfit(double entry, double stop, double take, double risk, double initialDeposit)
        {
            var persentageOfEntry = 100 / ((1 - stop / entry)) * risk / 100;

            var sumOfEntry = initialDeposit * persentageOfEntry / 100;

            return (take/entry - 1) * sumOfEntry;
        }
    }
}

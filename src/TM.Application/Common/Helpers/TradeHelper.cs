using TM.Domain.Entities;
using TM.Domain.Enums;

namespace TM.Application.Common.Helpers
{
    public static class TradeHelper
    {
        public static void Inizialize(this Trade trade, bool isUpdate)
        {
            trade.ID = isUpdate ? trade.ID : Guid.NewGuid().ToString();
            trade.Date = isUpdate ? trade.Date : DateTime.Now;
            trade.Date = trade.Date is null ? DateTime.Now : trade.Date;

            trade.RiskRewardRatio = CalculationHelper.GetRiskRewardRatio(trade.PriceEntry, trade.PriceStop, trade.PriceTake);
            trade.RiskAmount = CalculationHelper.GetRiskAmount(trade.InitialDeposit, trade.DepositRisk);

            if (trade.ResultType is null || trade.ResultType == ResultType.Take)
            {
                trade.Profit = CalculationHelper.GetProfit(trade.PriceEntry, trade.PriceStop, trade.PriceTake, trade.DepositRisk, trade.InitialDeposit, trade.PositionType);
            }
            else if (trade.ResultType == ResultType.Stop)
            {
                trade.Profit = -trade.RiskAmount;
            }
        }
    }
}

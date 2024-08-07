﻿using TM.Domain.Entities;
using TM.Domain.Enums;

namespace TM.Application.Common.Helpers
{
    public static class TradeHelper
    {
        public static void Inizialize(this Trade trade, bool isUpdate)
        {
            trade.ID = isUpdate ? trade.ID : Guid.NewGuid().ToString();
            trade.Date = isUpdate ? trade.Date : DateTime.Now;
            trade.ResultType = trade.ResultType is null ? ResultType.Pending : trade.ResultType;

            trade.Date = trade.Date is null ? DateTime.Now : trade.Date;

            trade.RiskRewardRatio = CalculationHelper.GetRiskRewardRatio(trade.PriceEntry, trade.PriceStop, trade.PriceTake);
            trade.RiskAmount = CalculationHelper.GetRiskAmount(trade.InitialDeposit, trade.DepositRisk);

            if (trade.ResultType == ResultType.Pending || trade.ResultType == ResultType.Take)
            {
                trade.Profit = CalculationHelper.GetProfit(trade.PriceEntry, trade.PriceStop, trade.PriceTake, trade.DepositRisk, trade.InitialDeposit, trade.PositionType);
            }
            else if (trade.ResultType == ResultType.Stop)
            {
                trade.Profit = trade.RiskAmount * -1;
            }
            else if(trade.ResultType == ResultType.BreakEven)
            {
                trade.Profit = 0;
            }
        }
    }
}

﻿using MediatR;
using TM.Application.Common.Models;

namespace TM.Application.Trades.Commands.CreateTrade
{
    public class CreateTradeCommand(TradeDTO tradeDTO) : IRequest
    {
        public TradeDTO TradeDTO { get; set; } = tradeDTO;
    }
}

﻿using MediatR;
using TM.Application.Common.Models;

namespace TM.Application.Trades.Commands
{
    public class UpdateTradeCommand(TradeDTO tradeDTO) : IRequest<TradeDTO>
    {
        public TradeDTO TradeDTO { get; set; } = tradeDTO;
    }
}

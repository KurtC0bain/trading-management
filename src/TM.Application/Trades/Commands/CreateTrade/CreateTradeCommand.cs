using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Application.Common.Models;

namespace TM.Application.Trades.Commands.CreateTrade
{
    public class CreateTradeCommand(TradeDTO tradeDTO) : IRequest
    {
        public TradeDTO TradeDTO { get; set; } = tradeDTO;
    }
}

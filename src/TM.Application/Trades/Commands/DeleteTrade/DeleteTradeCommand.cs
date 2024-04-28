using MediatR;
using TM.Application.Common.Models;

namespace TM.Application.Trades.Commands
{
    public class DeleteTradeCommand(string tradeId) : IRequest
    {
        public string TradeId { get; set; } = tradeId;
    }
}

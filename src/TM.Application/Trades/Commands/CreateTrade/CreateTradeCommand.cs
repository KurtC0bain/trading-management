using MediatR;
using TM.Application.Common.Models;

namespace TM.Application.Trades.Commands
{
    public class CreateTradeCommand(TradeDTO tradeDTO, string test) : IRequest<TradeDTO>
    {
        public string test {  get; } = test;
        public TradeDTO TradeDTO { get; } = tradeDTO;
    }
}

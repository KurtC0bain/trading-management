using MediatR;
using TM.Application.Common.Models;

namespace TM.Application.Trades.Queries
{
    public class GetTradeByIdQuery(string tradeId) : IRequest<TradeDTO>
    {
        public string TradeId { get; } = tradeId;
    }
}

using MediatR;
using TM.Domain.Entities;

namespace TM.Application.Trades.Queries
{
    public class GetTradeByIdQuery(string tradeId) : IRequest<Trade>
    {
        public string TradeId { get; } = tradeId;
    }
}

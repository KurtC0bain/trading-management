using MediatR;
using TM.Domain.Entities;

namespace TM.Application.Trades.Queries
{
    public class GetTradeByIdQuery(Guid tradeId) : IRequest<Trade>
    {
        public Guid TradeId { get; } = tradeId;
    }
}

using MediatR;
using TM.Application.Common.Models;
using TM.Application.Error.Models;

namespace TM.Application.Trades.Queries
{
    public class GetTradeByIdQuery(string tradeId) : IRequest<Result<InternalError, TradeDTO>>
    {
        public string TradeId { get; } = tradeId;
    }
}

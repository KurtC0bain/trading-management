using MediatR;
using TM.Application.Common.Models;
using TM.Application.Common.Models.Trades;
using TM.Application.Error.Models;

namespace TM.Application.Trades.Queries
{
    public class GetTradeByIdQuery(string tradeId) : IRequest<Result<InternalError, TradeResponse>>
    {
        public string TradeId { get; } = tradeId;
    }
}

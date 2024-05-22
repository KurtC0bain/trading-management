using MediatR;
using TM.Application.Common.Models.Trades;
using TM.Application.Error.Models;

namespace TM.Application.Trades.Commands
{
    public class CreateTradeCommand(CreateTradeRequest tradeRequest) : IRequest<Result<InternalError, TradeResponse>>
    {
        public CreateTradeRequest TradeRequest { get; } = tradeRequest ?? throw new ArgumentNullException(nameof(tradeRequest));
    }
}

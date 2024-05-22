using MediatR;
using TM.Application.Common.Models;
using TM.Application.Common.Models.Trades;
using TM.Application.Error.Models;

namespace TM.Application.Trades.Commands
{
    public class UpdateTradeCommand(UpdateTradeRequest tradeRequest) : IRequest<Result<InternalError, TradeResponse>>
    {
        public UpdateTradeRequest TradeRequest { get; set; } = tradeRequest;
    }
}

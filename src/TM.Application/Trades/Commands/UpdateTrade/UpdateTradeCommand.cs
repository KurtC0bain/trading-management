using MediatR;
using System.Security.Claims;
using TM.Application.Common.Models;
using TM.Application.Common.Models.Trades;
using TM.Application.Error.Models;

namespace TM.Application.Trades.Commands
{
    public class UpdateTradeCommand(UpdateTradeRequest tradeRequest) : IRequest<Result<InternalError, TradeResponse>>
    {
        public ClaimsPrincipal CurrentUser { get; set; }
        public UpdateTradeRequest TradeRequest { get; set; } = tradeRequest;
    }
}

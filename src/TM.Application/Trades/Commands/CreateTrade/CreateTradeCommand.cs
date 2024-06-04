using MediatR;
using System.Security.Claims;
using TM.Application.Common.Models.Trades;
using TM.Application.Error.Models;

namespace TM.Application.Trades.Commands
{
    public class CreateTradeCommand(CreateTradeRequest tradeRequest) : IRequest<Result<InternalError, TradeResponse>>
    {
        public ClaimsPrincipal CurrentUser { get; set; }
        public CreateTradeRequest TradeRequest { get; } = tradeRequest ?? throw new ArgumentNullException(nameof(tradeRequest));
    }
}

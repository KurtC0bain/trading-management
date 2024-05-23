using MediatR;
using System.Security.Claims;
using TM.Application.Common.Models.Trades;
using TM.Application.Error.Models;

namespace TM.Application.Trades.Commands
{
    public class DeleteTradeCommand(string tradeId) : IRequest<Result<InternalError, TradeResponse>>
    {
        public ClaimsPrincipal CurrentUser { get; set; }
        public string TradeId { get; set; } = tradeId;
    }
}

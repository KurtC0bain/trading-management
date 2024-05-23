using MediatR;
using System.Security.Claims;
using TM.Application.Common.Models.Trades;
using TM.Application.Error.Models;

namespace TM.Application.Trades.Queries
{
    public class GetTradeByIdQuery(string tradeId) : IRequest<Result<InternalError, TradeResponse>>
    {
        public ClaimsPrincipal CurrentUser { get; set; }
        public string TradeId { get; } = tradeId;
    }
}

using MediatR;
using System.Security.Claims;
using TM.Application.Common.Models;
using TM.Application.Common.Models.Trades;
using TM.Application.Error.Models;

namespace TM.Application.Trades.Queries
{
    public class GetAllTradesQuery : IRequest<Result<InternalError, List<TradeResponse>>>
    {
        public ClaimsPrincipal CurrentUser { get; set; }
    }
}

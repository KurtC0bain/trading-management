using MediatR;
using TM.Application.Common.Models;
using TM.Application.Error.Models;

namespace TM.Application.Trades.Queries
{
    public class GetAllTradesQuery : IRequest<Result<InternalError, List<TradeDTO>>>
    {
    }
}

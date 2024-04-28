using MediatR;
using TM.Application.Common.Models;
using TM.Domain.Entities;

namespace TM.Application.Trades.Queries
{
    public class GetAllTradesQuery : IRequest<List<TradeDTO>>
    {
    }
}

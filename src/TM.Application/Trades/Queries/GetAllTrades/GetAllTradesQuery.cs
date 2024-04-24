using MediatR;
using TM.Domain.Entities;

namespace TM.Application.Trades.Queries
{
    public class GetAllTradesQuery : IRequest<List<Trade>>
    {
    }
}

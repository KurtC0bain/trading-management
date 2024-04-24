using MediatR;
using TM.Application.Trades.Queries;
using TM.Domain.Entities;

namespace TM.Application.Trades.Handlers.GetAllTrades
{
    public class GetAllTradesHandler : IRequestHandler<GetAllTradesQuery, List<Trade>>
    {
        public GetAllTradesHandler()
        {
                
        }

        public Task<List<Trade>> Handle(GetAllTradesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

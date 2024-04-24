using MediatR;
using TM.Application.Trades.Queries;
using TM.Domain.Entities;

namespace TM.Application.Trades.Handlers.GetAllTrades
{
    public class GetTradeByIdHandler : IRequestHandler<GetTradeByIdQuery, Trade>
    {
        public GetTradeByIdHandler()
        {

        }

        public Task<Trade> Handle(GetTradeByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

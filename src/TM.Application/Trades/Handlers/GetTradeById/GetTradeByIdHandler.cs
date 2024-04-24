using MediatR;
using TM.Application.Common.Interfaces;
using TM.Application.Trades.Queries;
using TM.Domain.Entities;

namespace TM.Application.Trades.Handlers.GetAllTrades
{
    public class GetTradeByIdHandler(IRepositoryBase<Trade> repository) : IRequestHandler<GetTradeByIdQuery, Trade>
    {
        private readonly IRepositoryBase<Trade> _repository = repository;

        public async Task<Trade> Handle(GetTradeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FindByIdAsync(request.TradeId);
        }
    }
}

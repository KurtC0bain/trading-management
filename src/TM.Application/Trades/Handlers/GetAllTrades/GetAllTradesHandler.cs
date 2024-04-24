using MediatR;
using TM.Application.Common.Interfaces;
using TM.Application.Trades.Queries;
using TM.Domain.Entities;

namespace TM.Application.Trades.Handlers.GetAllTrades
{
    public class GetAllTradesHandler(IRepositoryBase<Trade> repository) : IRequestHandler<GetAllTradesQuery, List<Trade>>
    {
        private readonly IRepositoryBase<Trade> _repository = repository;

        public async Task<List<Trade>> Handle(GetAllTradesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}

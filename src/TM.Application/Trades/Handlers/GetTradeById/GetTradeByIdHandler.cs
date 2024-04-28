using AutoMapper;
using MediatR;
using TM.Application.Common.Interfaces;
using TM.Application.Common.Models;
using TM.Application.Trades.Queries;
using TM.Domain.Entities;

namespace TM.Application.Trades.Handlers.GetAllTrades
{
    public class GetTradeByIdHandler(IRepositoryBase<Trade> repository, IMapper mapper) : IRequestHandler<GetTradeByIdQuery, TradeDTO>
    {
        private readonly IRepositoryBase<Trade> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<TradeDTO> Handle(GetTradeByIdQuery request, CancellationToken cancellationToken)
        {
            var trade = await _repository.FindByIdAsync(request.TradeId);
            return _mapper.Map<TradeDTO>(trade);
        }
    }
}

using AutoMapper;
using MediatR;
using TM.Application.Common.Helpers;
using TM.Application.Common.Interfaces;
using TM.Application.Common.Models;
using TM.Application.Trades.Commands;
using TM.Domain.Entities;

namespace TM.Application.Trades.Handlers
{
    public class CreateTradeHandler(IRepositoryBase<Trade> repository, IMapper mapper) : IRequestHandler<CreateTradeCommand, TradeDTO>
    {
        private readonly IRepositoryBase<Trade> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<TradeDTO> Handle(CreateTradeCommand request, CancellationToken cancellationToken)
        {
            var trade = _mapper.Map<Trade>(request.TradeDTO);

            trade.Inizialize(false);

            var result = await _repository.AddAsync(trade);

            return _mapper.Map<TradeDTO>(result);
        }
    }
}

using AutoMapper;
using MediatR;
using TM.Application.Common.Helpers;
using TM.Application.Common.Interfaces;
using TM.Application.Trades.Commands;
using TM.Domain.Entities;

namespace TM.Application.Trades.Handlers
{
    public class UpdateTradeHandler(IRepositoryBase<Trade> repository, IMapper mapper) : IRequestHandler<UpdateTradeCommand>
    {
        private readonly IRepositoryBase<Trade> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task Handle(UpdateTradeCommand request, CancellationToken cancellationToken)
        {
            var trade = _mapper.Map<Trade>(request.TradeDTO);

            trade.Inizialize(true);

            await _repository.UpdateAsync(trade);
        }
    }
}

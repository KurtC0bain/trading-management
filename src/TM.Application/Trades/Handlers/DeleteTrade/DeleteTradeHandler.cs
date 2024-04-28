using AutoMapper;
using MediatR;
using TM.Application.Common.Interfaces;
using TM.Application.Trades.Commands;
using TM.Domain.Entities;

namespace TM.Application.Trades.Handlers
{
    public class DeleteTradeHandler(IRepositoryBase<Trade> repository, IMapper mapper) : IRequestHandler<DeleteTradeCommand>
    {
        private readonly IRepositoryBase<Trade> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task Handle(DeleteTradeCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.TradeId);
        }
    }
}

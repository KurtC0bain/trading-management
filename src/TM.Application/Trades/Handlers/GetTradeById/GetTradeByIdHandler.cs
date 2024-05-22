using AutoMapper;
using MediatR;
using TM.Application.Common.Interfaces;
using TM.Application.Common.Models;
using TM.Application.Common.Models.Trades;
using TM.Application.Error.Models;
using TM.Application.Trades.Queries;
using TM.Domain.Entities;

namespace TM.Application.Trades.Handlers
{
    public class GetTradeByIdHandler(IRepositoryBase<Trade> repository, IMapper mapper) : IRequestHandler<GetTradeByIdQuery, Result<InternalError, TradeResponse>>
    {
        private readonly IRepositoryBase<Trade> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<InternalError, TradeResponse>> Handle(GetTradeByIdQuery request, CancellationToken cancellationToken)
        {
            var trade = await _repository.FindByIdAsync(request.TradeId);

            if (trade is null)
                return new NotFoundError(request.TradeId);

            return _mapper.Map<TradeResponse>(trade);
        }
    }
}

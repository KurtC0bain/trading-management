using AutoMapper;
using MediatR;
using TM.Application.Common.Interfaces;
using TM.Application.Common.Models;
using TM.Application.Trades.Queries;
using TM.Domain.Entities;

namespace TM.Application.Trades.Handlers
{
    public class GetAllTradesHandler(IRepositoryBase<Trade> repository, IMapper mapper) : IRequestHandler<GetAllTradesQuery, List<TradeDTO>>
    {
        private readonly IRepositoryBase<Trade> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<TradeDTO>> Handle(GetAllTradesQuery request, CancellationToken cancellationToken)
        {
            var trades = await _repository.GetAllAsync();
            return _mapper.Map<List<TradeDTO>>(trades);
        }
    }
}

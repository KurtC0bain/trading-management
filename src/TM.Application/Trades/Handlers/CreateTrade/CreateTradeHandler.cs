using MediatR;
using MediatR.Pipeline;
using TM.Application.Common.Interfaces;
using TM.Application.Trades.Commands.CreateTrade;
using TM.Domain.Entities;

namespace TM.Application.Trades.Handlers.CreateTrade
{
    public class CreateTradeHandler(IRepositoryBase<Trade> repository) : IRequestHandler<CreateTradeCommand>
    {
        private readonly IRepositoryBase<Trade> _repository = repository;

        public async Task Handle(CreateTradeCommand request, CancellationToken cancellationToken)
        {
            var trade = new Trade
            {
                ID = Guid.NewGuid(),
                Date = DateTime.Now,
                Pair = new Pair 
                {
                    ID = Guid.NewGuid(),
                    Description = "test",
                    Name = "BTCUSDT"
                },
                UserID = Guid.NewGuid().ToString()
            };
            await _repository.AddAsync(trade);
        }
    }
}

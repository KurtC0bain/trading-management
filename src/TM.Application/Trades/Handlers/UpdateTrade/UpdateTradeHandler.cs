using AutoMapper;
using MediatR;
using TM.Application.Common.Helpers;
using TM.Application.Common.Interfaces;
using TM.Application.Trades.Commands.UpdateTrade;
using TM.Domain.Entities;

namespace TM.Application.Trades.Handlers.UpdateTrade
{
    public class UpdateTradeHandler(IRepositoryBase<Trade> repository, IMapper mapper) : IRequestHandler<UpdateTradeCommand>
    {
        private readonly IRepositoryBase<Trade> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task Handle(UpdateTradeCommand request, CancellationToken cancellationToken)
        {
            var trade = _mapper.Map<Trade>(request.TradeDTO);
            trade.ID = Guid.NewGuid().ToString();
            trade.UserID = Guid.NewGuid().ToString();
            trade.Date = DateTime.Now;
            trade.RiskRewardRatio = CalculationHelper.GetRiskRewardRatio(trade.PriceEntry, trade.PriceStop, trade.PriceTake);
            trade.Profit = CalculationHelper.GetProfit(trade.PriceEntry, trade.PriceStop, trade.PriceTake, trade.DepositRisk, trade.InitialDeposit);
            await _repository.UpdateAsync(trade);
        }
    }
}

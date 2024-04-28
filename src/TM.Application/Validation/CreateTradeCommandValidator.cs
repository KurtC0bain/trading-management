using FluentValidation;
using TM.Application.Trades.Commands;
using TM.Domain.Enums;

namespace TM.Application.Validation
{
    public class CreateTradeCommandValidator : AbstractValidator<CreateTradeCommand>
    {
        public CreateTradeCommandValidator()
        {
            RuleFor(x => x.TradeDTO.InitialDeposit == 0);

            RuleFor(x => x.TradeDTO.Profit)
                .GreaterThan(0).When(x => string.Equals(x.TradeDTO.ResultType, ResultType.Take.ToString()))
                .Equal(0).When(x => string.Equals(x.TradeDTO.ResultType,ResultType.BreakEven.ToString()) || x.TradeDTO.ResultType is null)
                .Equal(q => -q.TradeDTO.RiskAmount).When(x => string.Equals(x.TradeDTO.ResultType, ResultType.Stop.ToString()));

            RuleFor(x => x.TradeDTO.DepositRisk).InclusiveBetween(0, 100).NotEmpty();
            RuleFor(x => x.TradeDTO.RiskAmount).LessThanOrEqualTo(q => q.TradeDTO.InitialDeposit);
            RuleFor(x => x.TradeDTO.RiskRewardRatio).GreaterThan(0).When(x => x.TradeDTO.RiskRewardRatio is not null);

            RuleFor(x => x.TradeDTO.InitialDeposit).GreaterThan(0).NotEmpty();

            RuleFor(x => x.TradeDTO.PriceEntry).GreaterThan(0).NotEmpty();

            RuleFor(x => x.TradeDTO.PriceTake)
                .LessThan(x => x.TradeDTO.PriceEntry)
                    .When(x => string.Equals(x.TradeDTO.PositionType, PositionType.Short.ToString()))
                .GreaterThan(x => x.TradeDTO.PriceEntry)
                    .When(x => string.Equals(x.TradeDTO.PositionType, PositionType.Long.ToString()))
                .Equal(x => x.TradeDTO.PriceEntry)
                    .When(x => string.Equals(x.TradeDTO.PositionType, PositionType.Market.ToString()))
                .GreaterThan(0).NotEmpty();

            RuleFor(x => x.TradeDTO.PriceStop)
                .GreaterThan(x => x.TradeDTO.PriceEntry)
                    .When(x => string.Equals(x.TradeDTO.PositionType, PositionType.Short.ToString()))
                .LessThan(x => x.TradeDTO.PriceEntry)
                    .When(x => string.Equals(x.TradeDTO.PositionType, PositionType.Long.ToString()))
                .Equal(x => x.TradeDTO.PriceEntry)
                    .When(x => string.Equals(x.TradeDTO.PositionType, PositionType.Market.ToString()))
                .GreaterThan(0).NotEmpty();


            RuleFor(x => x.TradeDTO.Rating).InclusiveBetween(1, 5);

            RuleFor(x => x.TradeDTO.DirectionType).IsEnumName(typeof(DirectionType)); 
            RuleFor(x => x.TradeDTO.PositionType).IsEnumName(typeof(PositionType)); 
            RuleFor(x => x.TradeDTO.ResultType).IsEnumName(typeof(ResultType)).When(x => x.TradeDTO.ResultType is not null); 

            RuleFor(x => x.TradeDTO.SetupID).NotNull();
            RuleFor(x => x.TradeDTO.PairID).NotNull();


        }
    }
}

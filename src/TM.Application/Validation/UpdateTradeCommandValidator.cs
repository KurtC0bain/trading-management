using FluentValidation;
using TM.Application.Trades.Commands;
using TM.Domain.Enums;

namespace TM.Application.Validation
{
    public class UpdateTradeCommandValidator : AbstractValidator<UpdateTradeCommand>
    {
        public UpdateTradeCommandValidator()
        {
            //RuleFor(x => x.TradeRequest.Profit)
            //    .GreaterThan(0).When(x => string.Equals(x.TradeRequest.ResultType, ResultType.Take.ToString()), ApplyConditionTo.CurrentValidator)
            //    .Equal(0).When(x => string.Equals(x.TradeRequest.ResultType, ResultType.BreakEven.ToString()) || x.TradeRequest.ResultType is null, ApplyConditionTo.CurrentValidator)
            //    .Equal(q => -q.TradeRequest.RiskAmount).When(x => string.Equals(x.TradeRequest.ResultType, ResultType.Stop.ToString()), ApplyConditionTo.CurrentValidator);

            RuleFor(x => x.TradeRequest.DepositRisk).InclusiveBetween(0, 100).NotEmpty();
            //RuleFor(x => x.TradeRequest.RiskAmount).LessThanOrEqualTo(q => q.TradeRequest.InitialDeposit);
            //RuleFor(x => x.TradeRequest.RiskRewardRatio).GreaterThan(0).When(x => x.TradeRequest.RiskRewardRatio is not null);

            RuleFor(x => x.TradeRequest.InitialDeposit).GreaterThan(0).NotEmpty();

            RuleFor(x => x.TradeRequest.PriceEntry).GreaterThan(0).NotEmpty();

            RuleFor(x => x.TradeRequest.PriceTake)
                .LessThan(x => x.TradeRequest.PriceEntry)
                    .When(x => string.Equals(x.TradeRequest.PositionType, PositionType.Short.ToString()), ApplyConditionTo.CurrentValidator)
                .GreaterThan(x => x.TradeRequest.PriceEntry)
                    .When(x => string.Equals(x.TradeRequest.PositionType, PositionType.Long.ToString()), ApplyConditionTo.CurrentValidator)
                .Equal(x => x.TradeRequest.PriceEntry)
                    .When(x => string.Equals(x.TradeRequest.PositionType, PositionType.Market.ToString()), ApplyConditionTo.CurrentValidator)
                .GreaterThan(0).NotEmpty();

            RuleFor(x => x.TradeRequest.PriceStop)
                .GreaterThan(x => x.TradeRequest.PriceEntry)
                    .When(x => string.Equals(x.TradeRequest.PositionType, PositionType.Short.ToString()), ApplyConditionTo.CurrentValidator)
                .LessThan(x => x.TradeRequest.PriceEntry)
                    .When(x => string.Equals(x.TradeRequest.PositionType, PositionType.Long.ToString()), ApplyConditionTo.CurrentValidator)
                .Equal(x => x.TradeRequest.PriceEntry)
                    .When(x => string.Equals(x.TradeRequest.PositionType, PositionType.Market.ToString()), ApplyConditionTo.CurrentValidator)
                .GreaterThan(0).NotEmpty();


            RuleFor(x => x.TradeRequest.Rating).InclusiveBetween(1, 5);

            RuleFor(x => x.TradeRequest.DirectionType).IsEnumName(typeof(DirectionType));
            RuleFor(x => x.TradeRequest.PositionType).IsEnumName(typeof(PositionType));
            RuleFor(x => x.TradeRequest.ResultType).IsEnumName(typeof(ResultType)).When(x => x.TradeRequest.ResultType is not null);

            RuleFor(x => x.TradeRequest.SetupID).NotNull();
            RuleFor(x => x.TradeRequest.PairID).NotNull();

            //RuleFor(x => x.TradeRequest.Profit).NotNull().When(x => string.Equals(x.TradeRequest.ResultType, ResultType.EarlyExit.ToString()), ApplyConditionTo.CurrentValidator);
        }
    }
}

using FluentValidation;
using TM.Application.Trades.Queries;

namespace TM.Application.Validation
{
    public class GetTradeByIdQueryValidator : AbstractValidator<GetTradeByIdQuery>
    {
        public GetTradeByIdQueryValidator()
        {
            RuleFor(x => x.TradeId.ToString()).NotEqual("1");
        }
    }
}

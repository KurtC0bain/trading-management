using FluentValidation;
using TM.Application.Trades.Queries;

namespace TM.Application.Validation
{
    public class TradeDTOValidator : AbstractValidator<GetTradeByIdQuery>
    {
        public TradeDTOValidator()
        {
            //RuleFor(x => x.TradeId).Equal("1");
        }
    }
}

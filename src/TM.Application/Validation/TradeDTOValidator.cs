using FluentValidation;
using TM.Application.Trades.Commands;
using TM.Application.Trades.Queries;

namespace TM.Application.Validation
{
    public class TradeDTOValidator : AbstractValidator<GetAllTradesQuery>
    {
        public TradeDTOValidator()
        {
            RuleFor(x => x.ToString()).Equal("1");
        }
    }
}

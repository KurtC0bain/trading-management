using FluentValidation;
using TM.Application.Trades.Queries;

namespace TM.Application.Validation
{
    public class GetAllTradesQueryValidator : AbstractValidator<GetAllTradesQuery>
    {
        public GetAllTradesQueryValidator()
        {
            RuleFor(x => x);
        }
    }
}

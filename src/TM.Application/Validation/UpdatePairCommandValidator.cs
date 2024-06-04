using FluentValidation;
using TM.Application.Pairs.Commands;

namespace TM.Application.Validation
{
    public class UpdatePairCommandValidator : AbstractValidator<UpdatePairCommand>
    {
        public UpdatePairCommandValidator()
        {
            RuleFor(x => x.PairRequest.Name).MaximumLength(20).NotEmpty();
            RuleFor(x => x.PairRequest.Description).MaximumLength(100);
        }
    }
}

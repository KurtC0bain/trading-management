using FluentValidation;
using TM.Application.Pairs.Commands;

namespace TM.Application.Validation
{
    public class CreatePairCommandValidator : AbstractValidator<CreatePairCommand>
    {
        public CreatePairCommandValidator()
        {
            RuleFor(x => x.PairRequest.Name).MaximumLength(20).NotEmpty();
            RuleFor(x => x.PairRequest.Description).MaximumLength(100);
        }
    }
}

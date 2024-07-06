using FluentValidation;
using TM.Application.Factors.Commands;

namespace TM.Application.Validation
{
    public class UpdateFactorCommandValidator : AbstractValidator<UpdateFactorCommand>
    {
        public UpdateFactorCommandValidator()
        {
            RuleFor(x => x.FactorRequest.Name).MaximumLength(100).NotEmpty();
            RuleFor(x => x.FactorRequest.Description).MaximumLength(500);
            RuleFor(x => x.FactorRequest.Priority).GreaterThan(0).LessThan(10).NotEmpty();
        }
    }
}

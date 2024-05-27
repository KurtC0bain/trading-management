using FluentValidation;
using TM.Application.Setups.Commands;

namespace TM.Application.Validation
{
    public class CreateSetupCommandValidator : AbstractValidator<CreateSetupCommand>
    {
        public CreateSetupCommandValidator()
        {
            RuleFor(x => x.SetupRequest.Name).MaximumLength(20).NotEmpty();
            RuleFor(x => x.SetupRequest.Description).MaximumLength(150);
        }
    }
}

using FluentValidation;
using TM.Application.Setups.Commands;

namespace TM.Application.Validation
{
    public class CreateSetupCommandValidator : AbstractValidator<CreateSetupCommand>
    {
        public CreateSetupCommandValidator()
        {
            RuleFor(x => x.SetupRequest.Name).MaximumLength(100).NotEmpty();
            RuleFor(x => x.SetupRequest.Description).MaximumLength(1000);
        }
    }
}

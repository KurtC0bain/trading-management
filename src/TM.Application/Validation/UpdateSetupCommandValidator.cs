using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Application.Setups.Commands;

namespace TM.Application.Validation
{
    public class UpdateSetupCommandValidator : AbstractValidator<UpdateSetupCommand>
    {
        public UpdateSetupCommandValidator()
        {
            RuleFor(x => x.SetupRequest.Name).MaximumLength(100).NotEmpty();
            RuleFor(x => x.SetupRequest.Description).MaximumLength(1000);
        }
    }
}

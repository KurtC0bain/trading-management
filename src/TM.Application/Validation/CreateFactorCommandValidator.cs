﻿using FluentValidation;
using TM.Application.Factors.Commands;

namespace TM.Application.Validation
{
    public class CreateFactorCommandValidator : AbstractValidator<CreateFactorCommand>
    {
        public CreateFactorCommandValidator()
        {
            RuleFor(x => x.FactorRequest.Name).MaximumLength(50).NotEmpty();
            RuleFor(x => x.FactorRequest.Description).MaximumLength(500);
            RuleFor(x => x.FactorRequest.Priority).GreaterThan(0).LessThan(10).NotEmpty();
        }
    }
}

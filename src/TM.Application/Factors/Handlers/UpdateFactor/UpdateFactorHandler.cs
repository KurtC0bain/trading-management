using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Application.Common.Interfaces;
using TM.Application.Common.Models.Factors;
using TM.Application.Error.Models;
using TM.Application.Factors.Commands;
using TM.Domain.Entities;

namespace TM.Application.Factors.Handlers
{
    public class UpdateFactorHandler(IRepositoryBase<Factor> repository, IMapper mapper, IValidator<UpdateFactorCommand> validator, UserManager<IdentityUser> userManager)
    : IRequestHandler<UpdateFactorCommand, Result<InternalError, FactorResponse>>
    {
        private readonly IRepositoryBase<Factor> _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<UpdateFactorCommand> _validator = validator;
        private readonly UserManager<IdentityUser> _userManager = userManager;

        public async Task<Result<InternalError, FactorResponse>> Handle(UpdateFactorCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.GetUserAsync(request.CurrentUser);
            request.FactorRequest.UserID = currentUser?.Id;

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var validationError = new ValidationError(validationResult.Errors.Select(e => e.ErrorMessage));
                return new Result<InternalError, FactorResponse>(validationError);
            }

            var factor = _mapper.Map<Factor>(request.FactorRequest);
            factor.ID = request.FactorId;


            var updatedFactor = await _repository.UpdateAsync(factor);

            return _mapper.Map<FactorResponse>(updatedFactor);
        }
    }

}

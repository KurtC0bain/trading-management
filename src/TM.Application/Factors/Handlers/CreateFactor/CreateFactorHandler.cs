using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TM.Application.Common.Interfaces;
using TM.Application.Common.Models.Factors;
using TM.Application.Error.Models;
using TM.Application.Factors.Commands;
using TM.Domain.Entities;

namespace TM.Application.Factors.Handlers
{
    public class CreateFactorHandler(IRepositoryBase<Factor> repository, IMapper mapper, IValidator<CreateFactorCommand> validator, UserManager<IdentityUser> userManager)
    : IRequestHandler<CreateFactorCommand, Result<InternalError, FactorResponse>>
    {
        private readonly IRepositoryBase<Factor> _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<CreateFactorCommand> _validator = validator;
        private readonly UserManager<IdentityUser> _userManager = userManager;


        public async Task<Result<InternalError, FactorResponse>> Handle(CreateFactorCommand request, CancellationToken cancellationToken)
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
            factor.ID = Guid.NewGuid().ToString();

            var result = await _repository.AddAsync(factor);

            return new Result<InternalError, FactorResponse>(_mapper.Map<FactorResponse>(result));
        }
    }

}

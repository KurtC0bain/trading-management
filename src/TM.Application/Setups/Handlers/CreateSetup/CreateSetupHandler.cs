using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using TM.Application.Common.Interfaces;
using TM.Application.Common.Models.Setups;
using TM.Application.Error.Models;
using TM.Application.Setups.Commands;
using TM.Domain.Entities;

namespace TM.Application.Setups.Handlers
{
    public class CreateSetupHandler(IRepositoryBase<Setup> repository, IRepositoryBase<Factor> factorRepository, IMapper mapper, IValidator<CreateSetupCommand> validator, UserManager<IdentityUser> userManager)
: IRequestHandler<CreateSetupCommand, Result<InternalError, SetupResponse>>
    {
        private readonly IRepositoryBase<Setup> _repository = repository;
        private readonly IRepositoryBase<Factor> _factorRepository = factorRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<CreateSetupCommand> _validator = validator;
        private readonly UserManager<IdentityUser> _userManager = userManager;


        public async Task<Result<InternalError, SetupResponse>> Handle(CreateSetupCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.SetupRequest.UserID);
            if (user == null)
            {
                var userNotFoundError = new UserNotFoundError(request.SetupRequest.UserID);
                return new Result<InternalError, SetupResponse>(userNotFoundError);
            }

            var currentUser = await _userManager.GetUserAsync(request.CurrentUser);
            if (user.Id != currentUser?.Id)
            {
                return new Result<InternalError, SetupResponse>(new WrongUserError());
            }

            var factors = await _factorRepository.FindByConditionAsync(x => request.SetupRequest.Factors.Contains(x.ID));

            var errros = new List<string>();
            foreach (var factorId in request.SetupRequest.Factors)
            {
                if (!factors.Any(x => x.ID == factorId))
                    errros.Add($"Factor with ID {factorId} does not exist in system.");
            }

            if(errros.Count != 0)
                return new Result<InternalError, SetupResponse>(new NoFactorsFoundError(errros));

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var validationError = new ValidationError(validationResult.Errors.Select(e => e.ErrorMessage));
                return new Result<InternalError, SetupResponse>(validationError);
            }

            var setup = _mapper.Map<Setup>(request.SetupRequest);
            setup.ID = Guid.NewGuid().ToString();
            setup.Factors = factors;

            var result = await _repository.AddAsync(setup);

            return new Result<InternalError, SetupResponse>(_mapper.Map<SetupResponse>(result));
        }
    }

}

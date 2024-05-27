using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TM.Application.Common.Interfaces;
using TM.Application.Common.Models.Factors;
using TM.Application.Error.Models;
using TM.Application.Factors.Commands;
using TM.Domain.Entities;

namespace TM.Application.Factors.Handlers
{
    public class DeleteFactorHandler(IRepositoryBase<Factor> repository, IMapper mapper, UserManager<IdentityUser> userManager) : IRequestHandler<DeleteFactorCommand, Result<InternalError, FactorResponse>>
    {
        private readonly IRepositoryBase<Factor> _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly UserManager<IdentityUser> _userManager = userManager;

        public async Task<Result<InternalError, FactorResponse>> Handle(DeleteFactorCommand request, CancellationToken cancellationToken)
        {
            var factorToDelete = await _repository.FindByIdAsync(request.FactorId);
            if (factorToDelete is null)
                return new NotFoundError(request.FactorId);


            var currentUser = await _userManager.GetUserAsync(request.CurrentUser);
            if (factorToDelete?.UserID != currentUser?.Id)
            {
                return new Result<InternalError, FactorResponse>(new WrongUserError());
            }

            var factor = await _repository.DeleteAsync(request.FactorId);

            if (factor is null)
                return new NotFoundError(request.FactorId);

            return _mapper.Map<FactorResponse>(factor);
        }
    }

}

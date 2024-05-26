using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TM.Application.Common.Interfaces;
using TM.Application.Common.Models.Factors;
using TM.Application.Error.Models;
using TM.Application.Factors.Queries;
using TM.Domain.Entities;

namespace TM.Application.Factors.Handlers
{
    public class GetFactorByIdHandler(IRepositoryBase<Factor> repository, IMapper mapper, UserManager<IdentityUser> userManager) : IRequestHandler<GetFactorByIdQuery, Result<InternalError, FactorResponse>>
    {
        private readonly IRepositoryBase<Factor> _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly UserManager<IdentityUser> _userManager = userManager;

        public async Task<Result<InternalError, FactorResponse>> Handle(GetFactorByIdQuery request, CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.GetUserAsync(request.CurrentUser);

            var factor = await _repository.FindByIdAsync(request.FactorId);

            if (factor is null)
                return new NotFoundError(request.FactorId);

            if (factor.UserID != currentUser?.Id)
                return new Result<InternalError, FactorResponse>(new WrongUserError());

            return _mapper.Map<FactorResponse>(factor);
        }
    }

}

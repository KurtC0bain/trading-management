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
    public class GetAllFactorsHandler(IRepositoryBase<Factor> repository, IMapper mapper, UserManager<IdentityUser> userManager) : IRequestHandler<GetAllFactorsQuery, Result<InternalError, List<FactorResponse>>>
    {
        private readonly IRepositoryBase<Factor> _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly UserManager<IdentityUser> _userManager = userManager;

        public async Task<Result<InternalError, List<FactorResponse>>> Handle(GetAllFactorsQuery request, CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.GetUserAsync(request.CurrentUser);

            List<Factor> factors = await _repository.GetAllAsync();

            return _mapper.Map<List<FactorResponse>>(factors.Where(x => x.UserID == currentUser?.Id).OrderBy(x => x.Priority).ToList());
        }
    }

}

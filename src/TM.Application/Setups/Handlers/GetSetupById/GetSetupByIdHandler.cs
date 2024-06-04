using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Application.Common.Interfaces;
using TM.Application.Common.Models.Setups;
using TM.Application.Error.Models;
using TM.Application.Setups.Queries;
using TM.Domain.Entities;

namespace TM.Application.Setups.Handlers.GetSetupById
{
    public class GetSetupByIdHandler(IRepositoryBase<Setup> repository, IMapper mapper, UserManager<IdentityUser> userManager) : IRequestHandler<GetSetupByIdQuery, Result<InternalError, SetupResponse>>
    {
        private readonly IRepositoryBase<Setup> _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly UserManager<IdentityUser> _userManager = userManager;

        public async Task<Result<InternalError, SetupResponse>> Handle(GetSetupByIdQuery request, CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.GetUserAsync(request.CurrentUser);

            var setup = await _repository.FindByIdAsync(request.SetupId);

            if (setup is null)
                return new NotFoundError(request.SetupId);

            if (setup.UserID != currentUser?.Id)
                return new Result<InternalError, SetupResponse>(new WrongUserError());

            return _mapper.Map<SetupResponse>(setup);
        }
    }

}

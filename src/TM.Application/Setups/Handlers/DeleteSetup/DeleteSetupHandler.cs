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
using TM.Application.Setups.Commands;
using TM.Domain.Entities;

namespace TM.Application.Setups.Handlers.DeleteSetup
{
    public class DeleteSetupHandler(IRepositoryBase<Setup> repository, IMapper mapper, UserManager<IdentityUser> userManager) : IRequestHandler<DeleteSetupCommand, Result<InternalError, SetupResponse>>
    {
        private readonly IRepositoryBase<Setup> _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly UserManager<IdentityUser> _userManager = userManager;

        public async Task<Result<InternalError, SetupResponse>> Handle(DeleteSetupCommand request, CancellationToken cancellationToken)
        {
            var factorToDelete = await _repository.FindByIdAsync(request.SetupId);
            if (factorToDelete is null)
                return new NotFoundError(request.SetupId);


            var currentUser = await _userManager.GetUserAsync(request.CurrentUser);
            if (factorToDelete?.UserID != currentUser?.Id)
            {
                return new Result<InternalError, SetupResponse>(new WrongUserError());
            }

            var setup = await _repository.DeleteAsync(request.SetupId);

            if (setup is null)
                return new NotFoundError(request.SetupId);

            return _mapper.Map<SetupResponse>(setup);
        }
    }

}

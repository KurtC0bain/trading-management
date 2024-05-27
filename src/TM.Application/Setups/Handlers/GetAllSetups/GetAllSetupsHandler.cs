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

namespace TM.Application.Setups.Handlers.GetAllSetups
{
    public class GetAllSetupsHandler(IRepositoryBase<Setup> repository, IMapper mapper, UserManager<IdentityUser> userManager) : IRequestHandler<GetAllSetupsQuery, Result<InternalError, List<SetupResponse>>>
    {
        private readonly IRepositoryBase<Setup> _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly UserManager<IdentityUser> _userManager = userManager;

        public async Task<Result<InternalError, List<SetupResponse>>> Handle(GetAllSetupsQuery request, CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.GetUserAsync(request.CurrentUser);

            List<Setup> setups = await _repository.GetAllAsync();

            return _mapper.Map<List<SetupResponse>>(setups.Where(x => x.UserID == currentUser?.Id).ToList());
        }
    }

}

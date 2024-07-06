using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TM.Application.Analysis.Queries;
using TM.Application.Common.Interfaces;
using TM.Application.Common.Models.Analysis;
using TM.Application.Common.Models.Trades;
using TM.Application.Error.Models;
using TM.Domain.Entities;
using TM.Domain.Enums;

namespace TM.Application.Analysis.Handlers.GetSetupEfficiency
{
    public class GetSetupsEfficiencyQueryHandler(IRepositoryBase<Trade> repository, IRepositoryBase<Setup> setupRepository, UserManager<IdentityUser> userManager) : IRequestHandler<GetSetupsEfficiencyQuery, Result<InternalError, SetupsEfficiencyResponse>>
    {
        private readonly IRepositoryBase<Trade> _repository = repository;
        private readonly IRepositoryBase<Setup> _setupRepository = setupRepository;
        private readonly UserManager<IdentityUser> _userManager = userManager;

        public async Task<Result<InternalError, SetupsEfficiencyResponse>> Handle(GetSetupsEfficiencyQuery request, CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.GetUserAsync(request.CurrentUser);

            List<Trade> trades = await _repository.FindByConditionAsync(x => x.UserID == currentUser.Id);

            if (trades is null)
                return new NotTradesFoundError(trades?.Select(x => x.ID));

            var setups = trades.GroupBy(t => t.SetupID)
                               .Select(g => new SetupsEfficiency
                               {
                                   SetupId = g.Key,
                                   Efficiency = g.Count(t => t.ResultType == ResultType.Take) / (double)g.Count()
                               }).ToList();
            foreach (var item in setups)
            {
                item.SetupId = (await _setupRepository.FindByIdAsync(item.SetupId)).Name;
            }

            return new SetupsEfficiencyResponse { Setups = setups };
        }
    }

}

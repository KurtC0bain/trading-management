using MediatR;
using Microsoft.AspNetCore.Identity;
using TM.Application.Analysis.Queries;
using TM.Application.Common.Interfaces;
using TM.Application.Common.Models.Analysis;
using TM.Application.Error.Models;
using TM.Domain.Entities;

namespace TM.Application.Analysis.Handlers.GetAssetsIncome
{
    public class GetAssetsIncomeQueryHandler(IRepositoryBase<Trade> repository, IRepositoryBase<Pair> pairRepository, UserManager<IdentityUser> userManager) : IRequestHandler<GetAssetsIncomeQuery, Result<InternalError, AssetsIncomeResponse>>
    {
        private readonly IRepositoryBase<Trade> _repository = repository;
        private readonly IRepositoryBase<Pair> _pairRepository = pairRepository;
        private readonly UserManager<IdentityUser> _userManager = userManager;

        public async Task<Result<InternalError, AssetsIncomeResponse>> Handle(GetAssetsIncomeQuery request, CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.GetUserAsync(request.CurrentUser);

            List<Trade> trades = await _repository.FindByConditionAsync(x => x.UserID == currentUser.Id);

            if (trades is null)
                return new NotTradesFoundError(trades?.Select(x => x.ID));

            var assetsIncome = trades.GroupBy(t => t.PairID)
                                             .Select(g => new AssetIncome
                                             {
                                                 AssetId = g.Key,
                                                 Income = g.Sum(t => t.Profit)
                                             }).ToList();

            foreach (var item in assetsIncome)
            {
                item.AssetId = (await _pairRepository.FindByIdAsync(item.AssetId)).Name;
            }

            return new AssetsIncomeResponse { Assets = assetsIncome };
        }
    }

}

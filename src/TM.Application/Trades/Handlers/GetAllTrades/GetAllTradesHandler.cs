using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TM.Application.Common.Interfaces;
using TM.Application.Common.Models;
using TM.Application.Common.Models.Trades;
using TM.Application.Error.Models;
using TM.Application.Trades.Queries;
using TM.Domain.Entities;

namespace TM.Application.Trades.Handlers
{
    public class GetAllTradesHandler(IRepositoryBase<Trade> repository, IMapper mapper, UserManager<IdentityUser> userManager) : IRequestHandler<GetAllTradesQuery, Result<InternalError, List<TradeResponse>>>
    {
        private readonly IRepositoryBase<Trade> _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly UserManager<IdentityUser> _userManager = userManager;

        public async Task<Result<InternalError, List<TradeResponse>>> Handle(GetAllTradesQuery request, CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.GetUserAsync(request.CurrentUser);

            List<Trade> trades = await _repository.GetAllAsync();

            return _mapper.Map<List<TradeResponse>>(trades.Where(x => x.UserID == currentUser?.Id).OrderByDescending(x => x.Date).ToList());
        }
    }
}

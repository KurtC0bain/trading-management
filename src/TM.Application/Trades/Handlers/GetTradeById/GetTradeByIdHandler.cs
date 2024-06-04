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
    public class GetTradeByIdHandler(IRepositoryBase<Trade> repository, IMapper mapper, UserManager<IdentityUser> userManager) : IRequestHandler<GetTradeByIdQuery, Result<InternalError, TradeResponse>>
    {
        private readonly IRepositoryBase<Trade> _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly UserManager<IdentityUser> _userManager = userManager;

        public async Task<Result<InternalError, TradeResponse>> Handle(GetTradeByIdQuery request, CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.GetUserAsync(request.CurrentUser);

            var trade = await _repository.FindByIdAsync(request.TradeId);

            if (trade is null)
                return new NotFoundError(request.TradeId);

            if(trade.UserID != currentUser?.Id)
                return new Result<InternalError, TradeResponse>(new WrongUserError());

            return _mapper.Map<TradeResponse>(trade);
        }
    }
}

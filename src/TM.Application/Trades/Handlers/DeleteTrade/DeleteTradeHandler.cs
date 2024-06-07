using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TM.Application.Common.Interfaces;
using TM.Application.Common.Models.Trades;
using TM.Application.Error.Models;
using TM.Application.Trades.Commands;
using TM.Domain.Entities;

namespace TM.Application.Trades.Handlers
{
    public class DeleteTradeHandler(IRepositoryBase<Trade> repository, IMapper mapper, UserManager<IdentityUser> userManager) : IRequestHandler<DeleteTradeCommand, Result<InternalError, TradeResponse>>
    {
        private readonly IRepositoryBase<Trade> _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly UserManager<IdentityUser> _userManager = userManager;

        public async Task<Result<InternalError, TradeResponse>> Handle(DeleteTradeCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.GetUserAsync(request.CurrentUser);

            var tradeToDelete = await _repository.FindByIdAsync(request.TradeId);
            if (tradeToDelete is null) 
                return new NotFoundError(request.TradeId);


            if (tradeToDelete?.UserID != currentUser?.Id)
            {
                return new Result<InternalError, TradeResponse>(new WrongUserError());
            }

            var trade = await _repository.DeleteAsync(request.TradeId);

            if(trade is null)
                return new NotFoundError(request.TradeId);

            return _mapper.Map<TradeResponse>(trade);
        }
    }
}

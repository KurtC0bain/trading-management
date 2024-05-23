using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TM.Application.Common.Helpers;
using TM.Application.Common.Interfaces;
using TM.Application.Common.Models.Trades;
using TM.Application.Error.Models;
using TM.Application.Trades.Commands;
using TM.Domain.Entities;

namespace TM.Application.Trades.Handlers
{
    public class UpdateTradeHandler(IRepositoryBase<Trade> repository, IMapper mapper, IValidator<UpdateTradeCommand> validator, UserManager<IdentityUser> userManager)
        : IRequestHandler<UpdateTradeCommand, Result<InternalError, TradeResponse>>
    {
        private readonly IRepositoryBase<Trade> _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<UpdateTradeCommand> _validator = validator;
        private readonly UserManager<IdentityUser> _userManager = userManager;

        public async Task<Result<InternalError, TradeResponse>> Handle(UpdateTradeCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.TradeRequest.UserID);
            if (user == null)
            {
                var userNotFoundError = new UserNotFoundError(request.TradeRequest.UserID);
                return new Result<InternalError, TradeResponse>(userNotFoundError);
            }

            var currentUser = await _userManager.GetUserAsync(request.CurrentUser);
            if (user.Id != currentUser?.Id)
            {
                return new Result<InternalError, TradeResponse>(new WrongUserError());
            }

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var validationError = new ValidationError(validationResult.Errors.Select(e => e.ErrorMessage));
                return new Result<InternalError, TradeResponse>(validationError);
            }

            var trade = _mapper.Map<Trade>(request.TradeRequest);

            trade.Inizialize(true);

            var updatedTrade = await _repository.UpdateAsync(trade);

            return _mapper.Map<TradeResponse>(updatedTrade);
        }
    }
}

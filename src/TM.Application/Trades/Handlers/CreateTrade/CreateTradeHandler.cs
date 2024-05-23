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
    public class CreateTradeHandler(IRepositoryBase<Trade> repository, IMapper mapper, IValidator<CreateTradeCommand> validator, UserManager<IdentityUser> userManager)
        : IRequestHandler<CreateTradeCommand, Result<InternalError, TradeResponse>>
    {
        private readonly IRepositoryBase<Trade> _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<CreateTradeCommand> _validator = validator;
        private readonly UserManager<IdentityUser> _userManager = userManager;


        public async Task<Result<InternalError, TradeResponse>> Handle(CreateTradeCommand request, CancellationToken cancellationToken)
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

            trade.Inizialize(false);

            var result = await _repository.AddAsync(trade);

            return new Result<InternalError, TradeResponse>(_mapper.Map<TradeResponse>(result));
        }
    }
}

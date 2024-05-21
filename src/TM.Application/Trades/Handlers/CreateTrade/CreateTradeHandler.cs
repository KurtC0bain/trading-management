using AutoMapper;
using FluentValidation;
using MediatR;
using TM.Application.Common.Helpers;
using TM.Application.Common.Interfaces;
using TM.Application.Common.Models.Trades;
using TM.Application.Error.Models;
using TM.Application.Trades.Commands;
using TM.Domain.Entities;

namespace TM.Application.Trades.Handlers
{
    public class CreateTradeHandler(IRepositoryBase<Trade> repository, IMapper mapper, IValidator<CreateTradeCommand> validator)
        : IRequestHandler<CreateTradeCommand, Result<InternalError, TradeResponse>>
    {
        private readonly IRepositoryBase<Trade> _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<CreateTradeCommand> _validator = validator;

        public async Task<Result<InternalError, TradeResponse>> Handle(CreateTradeCommand request, CancellationToken cancellationToken)
        {
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

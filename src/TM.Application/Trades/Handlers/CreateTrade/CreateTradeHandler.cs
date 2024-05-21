using AutoMapper;
using FluentValidation;
using MediatR;
using TM.Application.Common.Helpers;
using TM.Application.Common.Interfaces;
using TM.Application.Common.Models;
using TM.Application.Error.Models;
using TM.Application.Trades.Commands;
using TM.Domain.Entities;

namespace TM.Application.Trades.Handlers
{
    public class CreateTradeHandler : IRequestHandler<CreateTradeCommand, Result<InternalError, TradeDTO>>
    {
        private readonly IRepositoryBase<Trade> _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateTradeCommand> _validator;

        public CreateTradeHandler(IRepositoryBase<Trade> repository, IMapper mapper, IValidator<CreateTradeCommand> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<Result<InternalError, TradeDTO>> Handle(CreateTradeCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var validationError = new ValidationError(validationResult.Errors.Select(e => e.ErrorMessage));
                return new Result<InternalError, TradeDTO>(validationError);
            }

            var trade = _mapper.Map<Trade>(request.TradeDTO);

            trade.Inizialize(false);

            var result = await _repository.AddAsync(trade);

            return new Result<InternalError, TradeDTO>(_mapper.Map<TradeDTO>(result));
        }
    }
}

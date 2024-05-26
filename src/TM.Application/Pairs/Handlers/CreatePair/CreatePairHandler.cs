using AutoMapper;
using FluentValidation;
using MediatR;
using TM.Application.Common.Interfaces;
using TM.Application.Common.Models.Pairs;
using TM.Application.Error.Models;
using TM.Application.Pairs.Commands;
using TM.Domain.Entities;

namespace TM.Application.Pairs.Handlers
{
    public class CreatePairHandler(IRepositoryBase<Pair> repository, IMapper mapper, IValidator<CreatePairCommand> validator)
    : IRequestHandler<CreatePairCommand, Result<InternalError, PairResponse>>
    {
        private readonly IRepositoryBase<Pair> _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<CreatePairCommand> _validator = validator;

        public async Task<Result<InternalError, PairResponse>> Handle(CreatePairCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var validationError = new ValidationError(validationResult.Errors.Select(e => e.ErrorMessage));
                return new Result<InternalError, PairResponse>(validationError);
            }

            var pair = _mapper.Map<Pair>(request.PairRequest);
            pair.ID = Guid.NewGuid().ToString();

            var result = await _repository.AddAsync(pair);

            return new Result<InternalError, PairResponse>(_mapper.Map<PairResponse>(result));
        }
    }

}

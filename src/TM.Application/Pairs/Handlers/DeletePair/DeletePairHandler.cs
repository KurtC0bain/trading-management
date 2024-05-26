using AutoMapper;
using MediatR;
using TM.Application.Common.Interfaces;
using TM.Application.Common.Models.Pairs;
using TM.Application.Error.Models;
using TM.Application.Pairs.Commands;
using TM.Domain.Entities;

namespace TM.Application.Pairs.Handlers
{
    public class DeletePairHandler(IRepositoryBase<Pair> repository, IMapper mapper) : IRequestHandler<DeletePairCommand, Result<InternalError, PairResponse>>
    {
        private readonly IRepositoryBase<Pair> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<InternalError, PairResponse>> Handle(DeletePairCommand request, CancellationToken cancellationToken)
        {
            var pairToDelete = await _repository.FindByIdAsync(request.PairId);
            if (pairToDelete is null)
                return new NotFoundError(request.PairId);

            var pair = await _repository.DeleteAsync(request.PairId);

            if (pair is null)
                return new NotFoundError(request.PairId);

            return _mapper.Map<PairResponse>(pair);
        }
    }

}

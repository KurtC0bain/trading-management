using AutoMapper;
using MediatR;
using TM.Application.Common.Interfaces;
using TM.Application.Common.Models.Pairs;
using TM.Application.Error.Models;
using TM.Application.Pairs.Queries;
using TM.Domain.Entities;

namespace TM.Application.Pairs.Handlers
{
    public class GetPairByIdHandler(IRepositoryBase<Pair> repository, IMapper mapper) : IRequestHandler<GetPairByIdQuery, Result<InternalError, PairResponse>>
    {
        private readonly IRepositoryBase<Pair> _repository = repository;
        private readonly IMapper _mapper = mapper;
        public async Task<Result<InternalError, PairResponse>> Handle(GetPairByIdQuery request, CancellationToken cancellationToken)
        {
            var pair = await _repository.FindByIdAsync(request.PairId);

            if (pair is null)
                return new NotFoundError(request.PairId);

            return _mapper.Map<PairResponse>(pair);
        }
    }

}

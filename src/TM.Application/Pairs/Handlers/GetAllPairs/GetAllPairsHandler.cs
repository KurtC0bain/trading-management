using AutoMapper;
using MediatR;
using TM.Application.Common.Interfaces;
using TM.Application.Common.Models.Pairs;
using TM.Application.Error.Models;
using TM.Application.Pairs.Queries;
using TM.Domain.Entities;

namespace TM.Application.Pairs.Handlers
{
    public class GetAllPairsHandler(IRepositoryBase<Pair> repository, IMapper mapper) : IRequestHandler<GetAllPairsQuery, Result<InternalError, List<PairResponse>>>
    {
        private readonly IRepositoryBase<Pair> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<InternalError, List<PairResponse>>> Handle(GetAllPairsQuery request, CancellationToken cancellationToken)
        {
            List<Pair> pairs = await _repository.GetAllAsync();

            return _mapper.Map<List<PairResponse>>(pairs);
        }
    }

}

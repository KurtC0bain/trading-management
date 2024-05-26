using MediatR;
using TM.Application.Common.Models.Pairs;
using TM.Application.Error.Models;

namespace TM.Application.Pairs.Queries
{
    public class GetPairByIdQuery(string pairId) : IRequest<Result<InternalError, PairResponse>>
    {
        public string PairId { get; } = pairId;
    }
}

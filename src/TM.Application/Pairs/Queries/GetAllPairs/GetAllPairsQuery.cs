using MediatR;
using TM.Application.Common.Models.Pairs;
using TM.Application.Error.Models;

namespace TM.Application.Pairs.Queries
{
    public class GetAllPairsQuery : IRequest<Result<InternalError, List<PairResponse>>>
    {
    }
}

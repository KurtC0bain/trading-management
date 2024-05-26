using MediatR;
using TM.Application.Common.Models.Pairs;
using TM.Application.Error.Models;

namespace TM.Application.Pairs.Commands
{
    public class CreatePairCommand(PairRequest pairRequest) : IRequest<Result<InternalError, PairResponse>>
    {
        public PairRequest PairRequest { get; } = pairRequest;
    }
}

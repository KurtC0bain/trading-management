using MediatR;
using TM.Application.Common.Models.Pairs;
using TM.Application.Error.Models;

namespace TM.Application.Pairs.Commands
{
    public class UpdatePairCommand(PairRequest pairRequest, string id) : IRequest<Result<InternalError, PairResponse>>
    {
        public PairRequest PairRequest { get; set; } = pairRequest;
        public string PairId { get; set; } = id;
    }
}

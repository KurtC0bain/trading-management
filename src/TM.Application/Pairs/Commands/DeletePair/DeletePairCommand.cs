using MediatR;
using TM.Application.Common.Models.Pairs;
using TM.Application.Error.Models;

namespace TM.Application.Pairs.Commands
{
    public class DeletePairCommand(string pairId) : IRequest<Result<InternalError, PairResponse>>
    {
        public string PairId { get; set; } = pairId;
    }
}

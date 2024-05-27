using MediatR;
using System.Security.Claims;
using TM.Application.Common.Models.Factors;
using TM.Application.Error.Models;

namespace TM.Application.Factors.Commands
{
    public class DeleteFactorCommand(string factorId, ClaimsPrincipal currentUser) : IRequest<Result<InternalError, FactorResponse>>
    {
        public string FactorId { get; set; } = factorId;
        public ClaimsPrincipal CurrentUser { get; set; } = currentUser;
    }
}

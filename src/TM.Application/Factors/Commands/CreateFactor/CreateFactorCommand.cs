using MediatR;
using System.Security.Claims;
using TM.Application.Common.Models.Factors;
using TM.Application.Error.Models;

namespace TM.Application.Factors.Commands
{
    public class CreateFactorCommand(FactorRequest factorRequest, ClaimsPrincipal currentUser) : IRequest<Result<InternalError, FactorResponse>>
    {
        public FactorRequest FactorRequest { get; } = factorRequest;
        public ClaimsPrincipal CurrentUser { get; set; } = currentUser;

    }
}

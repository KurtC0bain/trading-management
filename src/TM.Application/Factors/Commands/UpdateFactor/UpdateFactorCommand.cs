using MediatR;
using System.Security.Claims;
using TM.Application.Common.Models.Factors;
using TM.Application.Error.Models;

namespace TM.Application.Factors.Commands
{
    public class UpdateFactorCommand(FactorRequest factorRequest, string id, ClaimsPrincipal currentUser) : IRequest<Result<InternalError, FactorResponse>>
    {
        public FactorRequest FactorRequest { get; set; } = factorRequest;
        public string FactorId { get; set; } = id;
        public ClaimsPrincipal CurrentUser { get; set; } = currentUser;
    }
}

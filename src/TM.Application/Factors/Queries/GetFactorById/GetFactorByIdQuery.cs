using MediatR;
using System.Security.Claims;
using TM.Application.Common.Models.Factors;
using TM.Application.Error.Models;

namespace TM.Application.Factors.Queries
{
    public class GetFactorByIdQuery(string factorId, ClaimsPrincipal currentUser) : IRequest<Result<InternalError, FactorResponse>>
    {
        public ClaimsPrincipal CurrentUser { get; set; } = currentUser;
        public string FactorId { get; } = factorId;
    }
}

